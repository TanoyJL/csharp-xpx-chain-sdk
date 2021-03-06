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
using System.Collections.Generic;
using GuardNet;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Model.Transactions;

namespace ProximaX.Sirius.Chain.Sdk.Model.Mosaics
{
    /// <summary>
    ///     Class MosaicModification
    /// </summary>
    public class MosaicModification : ModifyAccountPropertyTransaction<IUInt64Id>
    {
        public static readonly int VALUE_BYTES_LENGTH = 8;


        /// <summary>
        ///     Initializes a new instance of the <see cref="MosaicModification" /> class.
        /// </summary>
        /// <param name="networkType"></param>
        /// <param name="version"></param>
        /// <param name="deadline"></param>
        /// <param name="maxFee"></param>
        /// <param name="propertyType"></param>
        /// <param name="propertyModifications"></param>
        /// <param name="signature"></param>
        /// <param name="signer"></param>
        /// <param name="transactionInfo"></param>
        public MosaicModification(NetworkType networkType, int version, Deadline deadline,
            PropertyType propertyType,
            IList<AccountPropertyModification<IUInt64Id>> propertyModifications,
            ulong? maxFee,
            string signature = null, PublicAccount signer = null,
            TransactionInfo transactionInfo = null) : base(networkType, version,
            EntityType.MODIFY_ACCOUNT_PROPERTY_MOSAIC, deadline, propertyType,
            propertyModifications, maxFee, signature, signer, transactionInfo)
        {
        }

        public static int CalculatePayloadSize(int modCount)
        {
            // property type, mod count, mods
            return 1 + 1 + (1 + VALUE_BYTES_LENGTH) * modCount;
        }

        protected override int GetPayloadSerializedSize()
        {
            return CalculatePayloadSize(Modifications.Count);
        }

        /// <summary>
        ///     GetValueBytesFromModification
        /// </summary>
        /// <param name="mod">The modification property</param>
        /// <returns>byte[]</returns>
        protected override byte[] GetValueBytesFromModification(AccountPropertyModification<IUInt64Id> mod)
        {
           
            var byteValues = BitConverter.GetBytes(mod.Value.Id);

            Guard.NotEqualTo(byteValues.Length, VALUE_BYTES_LENGTH,
                new ArgumentException(
                    $"MosaicId should be serialized to {VALUE_BYTES_LENGTH} bytes but was {byteValues.Length} from {mod.Value}"));

            return byteValues;
        }
    }
}