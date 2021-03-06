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

using Newtonsoft.Json.Linq;
using ProximaX.Sirius.Chain.Sdk.Infrastructure.DTO;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Model.Mosaics;
using ProximaX.Sirius.Chain.Sdk.Model.Namespaces;
using ProximaX.Sirius.Chain.Sdk.Model.Transactions;
using ProximaX.Sirius.Chain.Sdk.Utils;
using System;

namespace ProximaX.Sirius.Chain.Sdk.Infrastructure.Mapping
{
    public class AliasTransactionMapping : TransactionMapping
    {
        public new AliasTransaction Apply(JObject input)
        {
            return ToAliasTransaction(input, TransactionMappingHelper.CreateTransactionInfo(input));
        }

        private static AliasTransaction ToAliasTransaction(JObject tx, TransactionInfo txInfo)
        {
            var transaction = tx["transaction"].ToObject<JObject>();
            var version = transaction["version"];


            //Bug - It seems the dotnetcore does not 
            //understand the Integer.
            //The workaround it to double cast the version
            int versionValue;
            try
            {
                versionValue = (int)((uint)version);
            }
            catch (Exception)
            {
                versionValue = (int)version;
            }

            var network = TransactionMappingUtils.ExtractNetworkType(versionValue);
            var txVersion = TransactionMappingUtils.ExtractTransactionVersion(versionValue);

            var deadline = new Deadline(transaction["deadline"].ToObject<UInt64DTO>().ToUInt64());
            var maxFee = transaction["maxFee"]?.ToObject<UInt64DTO>().ToUInt64();
            var signature = transaction["signature"].ToObject<string>();
            var signer = new PublicAccount(transaction["signer"].ToObject<string>(), network);

            var namespaceId = new NamespaceId(transaction["namespaceId"].ToObject<UInt64DTO>().ToUInt64());
            var type = EntityTypeExtension.GetRawValue(transaction["type"].ToObject<int>());
            var actionType = TransactionMappingHelper.ExtractActionType(tx);

            AliasTransaction aliasTransaction = null;

            switch (type)
            {
                case EntityType.ADDRESS_ALIAS:
                    var addressHex = transaction["address"].ToObject<string>();
                    var address = Address.CreateFromHex(addressHex);
                    aliasTransaction = new AliasTransaction(network, txVersion, deadline, maxFee, type,
                        namespaceId, actionType, null, address, signature, signer, txInfo);
                    break;
                case EntityType.MOSAIC_ALIAS:
                    var mosaic = new MosaicId(transaction["mosaicId"].ToObject<UInt64DTO>().ToUInt64());
                    aliasTransaction = new AliasTransaction(network, txVersion, deadline, maxFee, type,
                        namespaceId, actionType, mosaic, null, signature, signer, txInfo);
                    break;
            }

            return aliasTransaction;
        }
    }
}