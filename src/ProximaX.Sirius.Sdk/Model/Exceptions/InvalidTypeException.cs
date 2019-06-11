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
using System.Runtime.Serialization;

namespace ProximaX.Sirius.Sdk.Model.Exceptions
{
    /// <summary>
    ///     Class InvalidTypeException&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">The type of the class</typeparam>
    public class InvalidTypeException<T> : Exception
    {
        public InvalidTypeException()
        {
        }

        public InvalidTypeException(string message)
            : base(message)
        {
        }

        public InvalidTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}