# LitJsonConfig
A Library For Saving/Loading A Config Easily With LitJson, Able To Entirely Serialize Objects Back And Forth.
# Example Usage
```csharp
internal static TestConfigClass JsonConfig = new TestConfigClass();

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
