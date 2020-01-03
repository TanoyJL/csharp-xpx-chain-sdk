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

namespace ProximaX.Sirius.Chain.Sdk.Model.Exchange
{
    public enum ExchangeOfferType
    {
        SELL = 0,
        BUY = 1
    }

    public static class ExchangeOfferTypeExtension
    {
        public static byte GetValueInByte(this ExchangeOfferType type)
        {
            return (byte)type;
        }

        public static ExchangeOfferType GetRawValue(int type)
        {
            switch (type)
            {
                case 0:
                    return ExchangeOfferType.SELL;
                case 1:
                    return ExchangeOfferType.BUY;
                default:
                    throw new ArgumentOutOfRangeException("Not support ExchangeOfferType");
            }
        }

    }
}