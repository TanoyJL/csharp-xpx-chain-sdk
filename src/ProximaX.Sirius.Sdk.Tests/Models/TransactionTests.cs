﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ProximaX.Sirius.Sdk.Model.Accounts;
using ProximaX.Sirius.Sdk.Model.Blockchain;
using ProximaX.Sirius.Sdk.Model.Mosaics;
using ProximaX.Sirius.Sdk.Model.Transactions;
using ProximaX.Sirius.Sdk.Model.Transactions.Messages;
using Xunit;

namespace ProximaX.Sirius.Sdk.Tests.Models
{
    public class TransactionTests
    {
        [Fact]
        public void Should_Serialize_And_Sign_Transaction()
        {
        
            var mosaics = new List<Mosaic>()
            {
                new Mosaic((new MosaicId(992621222383397347)).Id, 20)
            };

            var transferTransaction = TransferTransaction.Create(Deadline.Create(1),
                new Address("SBILTA367K2LX2FEXG5TFWAS7GEFYAGY7QLFBYKC", NetworkType.MIJIN_TEST),
                mosaics,
                PlainMessage.Create("test-message"),
                NetworkType.MIJIN_TEST,
                0
            );
            var account = Account.CreateFromPrivateKey("26b64cb10f005e5988a36744ca19e20d835ccc7c105aaa5f3b212da593180930", NetworkType.MIJIN_TEST);
            var signedTransaction = transferTransaction.SignWith(account);
            // var payload = signedTransaction.Payload;
            signedTransaction.Payload.Should().NotBeNullOrEmpty();
            signedTransaction.Hash.Should().NotBeNullOrEmpty();

        }
    }
}
