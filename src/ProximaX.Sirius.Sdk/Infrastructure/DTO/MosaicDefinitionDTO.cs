// Copyright 2019 ProximaX
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

using System.Text;
using Newtonsoft.Json;

namespace ProximaX.Sirius.Sdk.Infrastructure.DTO
{
    /// <summary>
    /// </summary>
    public class MosaicDefinitionDTO
    {
        /// <summary>
        ///     Gets or Sets MosaicId
        /// </summary>
        [JsonProperty(PropertyName = "mosaicId")]
        public UInt64DTO MosaicId { get; set; }

        /// <summary>
        ///     Gets or Sets Supply
        /// </summary>
        [JsonProperty(PropertyName = "supply")]
        public UInt64DTO Supply { get; set; }

        /// <summary>
        ///     Gets or Sets Height
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public UInt64DTO Height { get; set; }

        /// <summary>
        ///     Gets or Sets Owner
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or Sets Revision
        /// </summary>
        [JsonProperty(PropertyName = "revision")]
        public int? Revision { get; set; }

        /// <summary>
        ///     Gets or Sets Properties
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public MosaicPropertiesDTO Properties { get; set; }

        /// <summary>
        ///     Gets or Sets Levy
        /// </summary>
        [JsonProperty(PropertyName = "levy")]
        public object Levy { get; set; }


        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MosaicDefinitionDTO {\n");
            sb.Append("  MosaicId: ").Append(MosaicId).Append("\n");
            sb.Append("  Supply: ").Append(Supply).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Levy: ").Append(Levy).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}