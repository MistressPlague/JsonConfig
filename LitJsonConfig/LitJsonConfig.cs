using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace Libraries.LitJsonConfig
{
    /// <summary>
    /// A Example Config That Can Be Passed To The Methods SaveConfig() And LoadConfig().
    /// </summary>
    public class TestConfigClass
    {
        public int Test1 = 69;
        public string Test2 = "Test Text";
        public bool Test3 = true;
        public float Test4 = 69.987f;
        public string[] Test5 = { "Test 5 1", "Test 5 2" };
    }

    internal static class LitJsonConfig
    {
        /// <summary>
        /// Saves Your Type To Config - NOTE: Your Type MUST Be Public, Not Internal Or Private.
        /// </summary>
        /// <typeparam name="T">You Should Not Need To Explicitly Define This.</typeparam>
        /// <param name="type">Your Input Type, Such As A Public Class Of Items, Such As Ints, Bools And Strings.</param>
        /// <param name="DirToConfig">The Path To Your Configuration File To Create/Update.</param>
        /// <returns>A Tuple Of If It Was Successful, And A Message.</returns>
        internal static Tuple<bool, string> SaveConfig<T>(T type, string DirToConfig)
        {
            if (type == null)
            {
                return Tuple.Create(false, "Type Is Null!");
            }

            if (string.IsNullOrEmpty(DirToConfig))
            {
                return Tuple.Create(false, "DirToConfig Is Null Or Empty!");
            }

            try
            {
                File.WriteAllText(DirToConfig, JsonMapper.ToJson(type));

                return Tuple.Create(true, "Success - Config Saved!");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, "Exception Caught!\nException:\n\n" + ex);
            }
        }

        /// <summary>
        /// Loads Your Config And Writes It To Your Type - NOTE: Your Type MUST Be Public, Not Internal Or Private.
        /// </summary>
        /// <typeparam name="T">You Should Not Need To Explicitly Define This.</typeparam>
        /// <param name="type">Your Input Type, Such As A Public Class Of Items, Such As Ints, Bools And Strings.</param>
        /// <param name="DirToConfig">The Path To Your Configuration File To Load From/Create With Default Values In The Type Provided.</param>
        /// <returns>A Tuple Of If It Was Successful, And A Message.</returns>
        internal static Tuple<bool, string> LoadConfig<T>(ref T type, string DirToConfig)
        {
            if (type == null)
            {
                return Tuple.Create(false, "Type Is Null!");
            }

            if (string.IsNullOrEmpty(DirToConfig))
            {
                return Tuple.Create(false, "DirToConfig Is Null Or Empty!");
            }

            if (!File.Exists(DirToConfig))
            {
                return SaveConfig(type, DirToConfig);
            }

            try
            {
                type = JsonMapper.ToObject<T>(File.ReadAllText(DirToConfig));

                return Tuple.Create(true, "Success - Config Loaded!");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, "Exception Caught!\nException:\n\n" + ex);
            }
        }
    }
}
