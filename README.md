# Notice:
For Use In MelonLoader Mods Or Such Where Newtonsoft.Json Is Needed To Be Used, [Click Here](https://github.com/MistressPlague/JsonConfig/tree/6b0d69e5f536dc4155d0ca9059c9256f2097e302)

# JsonConfig
The **Fastest** Json Config Library For Saving/Loading A Config Easily With Json, Able To Entirely Serialize Objects Back And Forth, Especially Ideal For MelonLoader Mods For Games Such As VRChat.

**If You Use This In Your Project, Please Star This Repo So I Can Have A Look, Might Even Help You Dev It! <3**

`NOTE: Use Of This In Your Project Requires It Contain My Original` [LICENSE](https://github.com/OFWModz/JsonConfig/blob/main/LICENSE) `File, Named LICENSE_PLAGUE & Have:` "[JsonConfig](https://github.com/OFWModz/JsonConfig), Licensed Under The Use-Only License" `In Your README.md - You Must Also Use The Same License Or No License - Copyright Disclaimers Are To Be Preserved. - Modification Is Not Permitted. Only Use And Distribution With The Original LICENSE Intact. - Optionally You Can Not Include My Source In Your Repo And Only Include The LICENSE.`

**NOTE: Use Of This Requires You Add Spreads.Utf8Json To Your Project. Click Tools > NuGet Package Manager > Package Manager Console Then Type: `Install-Package Spreads.Utf8Json -Version 1.0.0-build1903051941R`**

JsonConfig Standalone .cs File: [JsonConfig.cs](https://github.com/OFWModz/JsonConfig/blob/main/JsonConfigTest/JsonConfigTest/Libraries/JsonConfig.cs)

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
    var Output = JsonConfig.LoadConfig(ref JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}

private void EditAndSaveConfigButton_Click(object sender, EventArgs e)
{
    JsonConfig.Test2 = "I WAS EDITED! HOORAY!";

    var Output = JsonConfig.SaveConfig(JsonConfig, Environment.CurrentDirectory + "\\TestConfig.json");

    MessageBox.Show(Output.Item1 + " - " + Output.Item2);
}
```

# Info:
Method | Function
------------ | -------------
JsonConfig.LoadConfig<T>(T type, string DirToConfig) | Loads The Config File At The Dir Specified Then Applies All The Found Matching Values To Your Input Type (Such As A Class).
JsonConfig.SaveConfig<T>(T type, string DirToConfig, bool Readable = true) | Saves The Config File At The Dir Specified With All Of The Values Found In The Input Type (Such As Ints, Bools, Etc) - NOTE: bool Readable Specifies If You Want The Config To Be Readable By The Average User.

# To-Do:
- [x] Make Easier To Use
- [x] Add Ability To Effectively Obfuscate The Config Via A Parameter (Default Is Readable)
- [x] Finish Documentation
