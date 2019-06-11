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

using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace ProximaX.Sirius.Sdk.Infrastructure.DTO
{
    /// <summary>
    /// </summary>
    [DataContract]
    public class BlockchainScoreDTO
    {
        /// <summary>
        ///     Gets or Sets ScoreHigh
        /// </summary>
        [DataMember(Name = "scoreHigh", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scoreHigh")]
        public UInt64DTO ScoreHigh { get; set; }

        /// <summary>
        ///     Gets or Sets ScoreLow
        /// </summary>
        [DataMember(Name = "scoreLow", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scoreLow")]
        public UInt64DTO ScoreLow { get; set; }


        /// <summary>
        ///     Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlockchainScoreDTO {\n");
            sb.Append("  ScoreHigh: ").Append(ScoreHigh).Append("\n");
            sb.Append("  ScoreLow: ").Append(ScoreLow).Append("\n");
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