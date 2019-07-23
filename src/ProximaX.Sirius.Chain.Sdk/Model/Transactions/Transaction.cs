﻿// Copyright 2019 ProximaX
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using Org.BouncyCastle.Crypto.Digests;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Utils;

namespace ProximaX.Sirius.Chain.Sdk.Model.Transactions
{
    public abstract class Transaction
    {
        protected Transaction(NetworkType networkType, int version, TransactionType transactionType, Deadline deadline,
            ulong? maxFee, string signature = null, PublicAccount signer = null, TransactionInfo transactionInfo = null)
        {
            TransactionType = transactionType;
            NetworkType = networkType;
            Version = version;
            Deadline = deadline;
            MaxFee = maxFee;
            Signature = signature;
            Signer = signer;
            TransactionInfo = transactionInfo;
        }

        /// <summary>
        ///     The transaction type
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        ///     The network type
        /// </summary>
        public NetworkType NetworkType { get; set; }

        /// <summary>
        ///     Transaction version
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        ///     The deadline to include the transaction.
        /// </summary>
        public Deadline Deadline { get; set; }

        /// <summary>
        ///     A sender of a transaction must specify during the transaction definition a max_fee,
        ///     meaning the maximum fee the account allows to spend for this transaction.
        /// </summary>
        public ulong? MaxFee { get; set; }

        /// <summary>
        ///     The transaction signature (missing if part of an aggregate transaction).
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        ///     The account of the transaction creator.
        /// </summary>
        public PublicAccount Signer { get; set; }

        /// <summary>
        ///     Transactions meta data object contains additional information about the transaction.
        /// </summary>
        public TransactionInfo TransactionInfo { get; set; }

        /// <summary>
        ///     Gets or sets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        private byte[] Bytes { get; set; }

        /// <summary>
        ///     Gets the signer.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        internal byte[] GetSigner()
        {
            return Signer == null ? new byte[32] : Signer.PublicKey.DecodeHexString();
        }

        /// <summary>
        ///     Signs the transaction with the given <see cref="Account" />.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public SignedTransaction SignWith(Account account, string generationHash)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            
            var generationHashBytes = Org.BouncyCastle.Utilities.Encoders.Hex.Decode(generationHash); //generationHash.DecodeHexString();
            var testHash = generationHash.DecodeHexString();

            Bytes = GenerateBytes();

            var signingBytes = new byte[Bytes.Length - 100 + 32];

            Buffer.BlockCopy(generationHashBytes, 0, signingBytes, 0, 32);

            Buffer.BlockCopy(Bytes, 100, signingBytes, 32, Bytes.Length - 100);

            Signer = PublicAccount.CreateFromPublicKey(account.KeyPair.PublicKeyString, NetworkType);

            var signature = TransactionExtensions.SignTransaction(account.KeyPair, signingBytes);

            var payload = new byte[Bytes.Length];

            Buffer.BlockCopy(Bytes, 0, payload, 0, 4);

            Buffer.BlockCopy(signature, 0, payload, 4, signature.Length);

            var rawSignerPublicKey = account.KeyPair.PublicKey;

            Buffer.BlockCopy(rawSignerPublicKey, 0, payload, 64 + 4, rawSignerPublicKey.Length);

            Buffer.BlockCopy(Bytes, 100, payload, 100, Bytes.Length - 100);

            var hash = CreateTransactionHash(payload, generationHashBytes);

            return SignedTransaction.Create(payload, hash,
                account.KeyPair.PublicKey, TransactionType, NetworkType);
            /*
            var generationHashBytes = generationHash.DecodeHexString();

            Bytes = GenerateBytes();

            var signingBytes = generationHashBytes.Concat(
                     Bytes.Take(4 + 64 + 32)
                ).ToArray();

            Signer = PublicAccount.CreateFromPublicKey(account.KeyPair.PublicKeyString, NetworkType);


            var signature = TransactionExtensions.SignTransaction(account.KeyPair, signingBytes);

            var signedBuffer = Bytes.Take(4)
                .Concat(signature)
                .Concat(account.KeyPair.PublicKey)
                .Concat(
                    Bytes.Take(4+ 64 + 32, Bytes.Length - (4+ 64+32))
                ).ToArray();
            
            return SignedTransaction.Create(signedBuffer, TransactionExtensions.Hasher(signedBuffer,generationHashBytes),
                account.KeyPair.PublicKey, TransactionType, NetworkType);*/
            
        }

        public static byte[] CreateTransactionHash(byte[] payloadBytes, byte[] generationHashBytes)
        {
            // expected size is payload - 4 bytes
            byte[] signingBytes = new byte[payloadBytes.Length - 4];
            // 32 bytes = skip 4 bytes and take half of the signature
            Buffer.BlockCopy(payloadBytes, 4, signingBytes, 0, 32);
            // 32 bytes = skip second half of signature and take signer
            Buffer.BlockCopy(payloadBytes, 68, signingBytes, 32, 32);
            // 32 bytes = generation hash
            Buffer.BlockCopy(generationHashBytes, 0, signingBytes, 64, 32);
            // remainder
            Buffer.BlockCopy(payloadBytes, 100, signingBytes, 96, payloadBytes.Length - 100);

            var hash = new byte[32];
            var sha3Hasher = new Sha3Digest(256);
            sha3Hasher.BlockUpdate(signingBytes, 0, signingBytes.Length);
            sha3Hasher.DoFinal(hash, 0);

            return hash;
        }


        /// <summary>
        ///     Convert an aggregate transaction to an inner transaction including transaction signer.
        /// </summary>
        /// <param name="signer">Transaction signer</param>
        /// <returns>Transaction</returns>
        public Transaction ToAggregate(PublicAccount signer)
        {
            Signer = PublicAccount.CreateFromPublicKey(signer.PublicKey, NetworkType);

            return this;
        }

        /// <summary>
        ///     Transaction pending to be included in a block
        /// </summary>
        /// <returns>bool</returns>
        public bool IsUnconfirmed()
        {
            return TransactionInfo != null && TransactionInfo.Height == 0 && TransactionInfo.Hash ==
                   TransactionInfo.MerkleComponentHash;
        }

        /// <summary>
        ///     Transaction included in a block
        /// </summary>
        /// <returns>bool</returns>
        public bool IsConfirmed()
        {
            return TransactionInfo != null && TransactionInfo.Height > 0;
        }

        /// <summary>
        ///     Transaction is not known by the network
        /// </summary>
        /// <returns>bool</returns>
        public bool IsUnannounced()
        {
            return TransactionInfo == null;
        }

        /// <summary>
        ///     Takes a transaction and formats the bytes to be included in an aggregate transaction
        /// </summary>
        /// <returns>System.Byte[].</returns>
        internal byte[] ToAggregate()
        {
            var bytes = GenerateBytes();

            var aggregate = bytes.Take(4 + 64, 32 + 2 + 2)
                .Concat(
                    bytes.Take(4 + 64 + 32 + 2 + 2 + 8 + 8, bytes.Length - (4 + 64 + 32 + 2 + 2 + 8 + 8))
                ).ToArray();

            return BitConverter.GetBytes(aggregate.Length + 4).Concat(aggregate).ToArray();
        }

        /// <summary>
        ///     Generates the bytes.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        internal abstract byte[] GenerateBytes();
    }
}