using LitJson;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

/// <summary>
/// Copyright (c) Plague 2021 | LitJsonConfig By Plague.
/// </summary>
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
        /// Helper Methods
        /// </summary>
        private class Helpers
        {
            /// <summary>
            /// Compresses the string.
            /// </summary>
            /// <param name="text">The text.</param>
            /// <returns></returns>
            public static string CompressString(string text)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                var memoryStream = new MemoryStream();
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gZipStream.Write(buffer, 0, buffer.Length);
                }

                memoryStream.Position = 0;

                var compressedData = new byte[memoryStream.Length];
                memoryStream.Read(compressedData, 0, compressedData.Length);

                var gZipBuffer = new byte[compressedData.Length + 4];
                Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
                Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
                return Convert.ToBase64String(gZipBuffer);
            }

            /// <summary>
            /// Decompresses the string.
            /// </summary>
            /// <param name="compressedText">The compressed text.</param>
            /// <returns></returns>
            public static string DecompressString(string compressedText)
            {
                byte[] gZipBuffer = Convert.FromBase64String(compressedText);
                using (var memoryStream = new MemoryStream())
                {
                    int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                    memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                    var buffer = new byte[dataLength];

                    memoryStream.Position = 0;
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gZipStream.Read(buffer, 0, buffer.Length);
                    }

                    return Encoding.UTF8.GetString(buffer);
                }
            }
        }

        /// <summary>
        /// Saves Your Type To Config - NOTE: Your Type MUST Be Public, Not Internal Or Private.
        /// </summary>
        /// <typeparam name="T">You Should Not Need To Explicitly Define This.</typeparam>
        /// <param name="type">Your Input Type, Such As A Public Class Of Items, Such As Ints, Bools And Strings.</param>
        /// <param name="DirToConfig">The Path To Your Configuration File To Create/Update.</param>
        /// <param name="Readable">Whether You Want This Config To Be Readable By The Average User.</param>
        /// <returns>A Tuple Of If It Was Successful, And A Message.</returns>
        internal static Tuple<bool, string> SaveConfig<T>(T type, string DirToConfig, bool Readable = true)
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
                if (Readable)
                {
                    File.WriteAllText(DirToConfig, JsonMapper.ToJson(type));
                }
                else
                {
                    File.WriteAllText(DirToConfig, Helpers.CompressString(JsonMapper.ToJson(type)));
                }

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
                var Contents = File.ReadAllText(DirToConfig);

                try
                {
                    Contents = Helpers.DecompressString(Contents);
                }
                catch
                {

                }

                type = JsonMapper.ToObject<T>(Contents);

                return Tuple.Create(true, "Success - Config Loaded!");
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, "Exception Caught!\nException:\n\n" + ex);
            }
        }
    }
}
