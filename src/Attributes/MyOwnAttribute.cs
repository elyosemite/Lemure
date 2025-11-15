using System;

namespace lemure.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class MyOwnAttribute : Attribute
{
	private bool myValue;
	private string description;
	private Guid codeGenerated;
	public MyOwnAttribute(bool myValues, string description)
	{
		this.myValue = myValues;
		this.description = description;
		this.codeGenerated = Guid.NewGuid();
	}

	public virtual bool MyValue
	{
		get { return myValue; }
	}

	public virtual string Description
	{
		get { return description; }
	}

	/*public virtual IContractAttribute Contract
{
	get { return contract; }
	set { this.contract = value; }
}*/

	public virtual string CodeGenerated
	{
		get { return codeGenerated.ToString(); }
	}

}
