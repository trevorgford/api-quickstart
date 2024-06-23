namespace MyProject.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ModelNameAttribute(string name) : Attribute {

    public string Name { get; } = name;

}
