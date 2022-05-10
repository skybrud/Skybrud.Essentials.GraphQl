namespace Skybrud.Essentials.GraphQl {
    
    public class VariableReference {

        public string Name { get; }

        public VariableReference(string name) {
            Name = name;
        }

        public static VariableReference Create(string name) {
            return new(name);
        }

    }

}