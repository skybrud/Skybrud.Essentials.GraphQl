using System;

namespace Skybrud.Essentials.GraphQl {
    
    public class FieldAttribute : Attribute {

        public string Name { get; }

        public FieldAttribute(string name) {
            Name = name;
        }

    }

}