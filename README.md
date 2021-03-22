# LitJsonConfig
A Library For Saving/Loading A Config Easily With LitJson, Able To Entirely Serialize Objects Back And Forth.

If You Use This In Your Project, Please Star This Repo So I Can Have A Look, Might Even Help You Dev It! <3

NOTE: Use Of This In Your Project Requires It Be Open Source, Contain My Original [LICENSE](https://github.com/OFWModz/LitJsonConfig/blob/main/LICENSE) File, Named LICENSE_PLAGUE & Have "[LitJsonConfig](https://github.com/OFWModz/LitJsonConfig), Licensed Under The GPL-3.0 License" In Your README.md
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

private void LoadConfigButton_Click(object sender, EventArgs e)
{
    var Output = LitJsonConfig.LoadConfig(ref JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}

private void EditAndSaveConfigButton_Click(object sender, EventArgs e)
{
    JsonConfig.Test2 = "I WAS EDITED! HOORAY!";

    var Output = LitJsonConfig.SaveConfig(JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}
