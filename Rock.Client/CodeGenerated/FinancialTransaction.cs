//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
// Copyright 2013 by the Spark Development Network
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
// </copyright>
//
using System;
using System.Collections.Generic;


namespace Rock.Client
{
    /// <summary>
    /// Simple Client Model for FinancialTransaction
    /// </summary>
    public partial class FinancialTransaction
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public int? AuthorizedPersonAliasId { get; set; }

        /// <summary />
        public int? BatchId { get; set; }

        /// <summary />
        public string CheckMicrEncrypted { get; set; }

        /// <summary />
        public string CheckMicrHash { get; set; }

        /// <summary />
        public DefinedValue CreditCardTypeValue { get; set; }

        /// <summary />
        public int? CreditCardTypeValueId { get; set; }

        /// <summary />
        public DefinedValue CurrencyTypeValue { get; set; }

        /// <summary />
        public int? CurrencyTypeValueId { get; set; }

        /// <summary />
        public EntityType GatewayEntityType { get; set; }

        /// <summary />
        public int? GatewayEntityTypeId { get; set; }

        /// <summary />
        public ICollection<FinancialTransactionImage> Images { get; set; }

        /// <summary />
        public int? ScheduledTransactionId { get; set; }

        /// <summary />
        public DefinedValue SourceTypeValue { get; set; }

        /// <summary />
        public int? SourceTypeValueId { get; set; }

        /// <summary />
        public string Summary { get; set; }

        /// <summary />
        public string TransactionCode { get; set; }

        /// <summary />
        public DateTime? TransactionDateTime { get; set; }

        /// <summary />
        public ICollection<FinancialTransactionDetail> TransactionDetails { get; set; }

        /// <summary />
        public DefinedValue TransactionTypeValue { get; set; }

        /// <summary />
        public int TransactionTypeValueId { get; set; }

        /// <summary />
        public DateTime? CreatedDateTime { get; set; }

        /// <summary />
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary />
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary />
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public string ForeignId { get; set; }

        /// <summary />
        public Dictionary<string, Rock.Client.Attribute> Attributes { get; set; }


        /// <summary />
        public Dictionary<string, Rock.Client.AttributeValue> AttributeValues { get; set; }

    }
}
