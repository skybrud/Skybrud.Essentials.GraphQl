using System;

namespace Skybrud.Essentials.GraphQl {
    
    public class ParameterAttribute : Attribute {

        public string Name { get; }

        public ParameterAttribute(string name) {
            Name = name;
        }

    }

}