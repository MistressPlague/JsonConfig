# LitJsonConfig
A Library For Saving/Loading A Config Easily With LitJson, Able To Entirely Serialize Objects Back And Forth.
# Example Usage
```csharp
public class ConfigTest
{
    public int Test1 = 69;
    public string Test2 = "Test Text";
    public bool Test3 = true;
    public float Test4 = 69.987f;
    public string[] Test5 = { "Test 5 1", "Test 5 2" };
}

internal static ConfigTest JsonConfig = new ConfigTest();

private void button2_Click(object sender, EventArgs e)
{
    var Output = LitJsonConfig.LoadConfig(ref JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}

private void button3_Click(object sender, EventArgs e)
{
    JsonConfig.Test2 = "I WAS EDITED! HOORAY!";

    var Output = LitJsonConfig.SaveConfig(JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}
