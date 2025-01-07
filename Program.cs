using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using  System.Text.RegularExpressions;

namespace NotificationChannelParser{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("🚀Notification Channel Parser🚀\n");
            Console.WriteLine("Enter notification  titles  to parse their channels.\n");
            Console.WriteLine("Type 'exit' to quit.\n");

            while(true){

                // User Input
                Console.Write("Enter a notification title : ");
                string input = Console.ReadLine();

                // Exit Condition
                if(input.ToLower() == "exit"){
                    Console.WriteLine("\n👋 Thank you for using the notification Channel Parser . Goodbye! 👋");
                    break;
                }

                //Parse the input and display the result
                List<string> channels = ParseNotificationTitle(input);
                DisplayOutput(channels);
            }

        }
        static List<string> ParseNotificationTitle(string title){
            // Define the expression valid channels
            HashSet<string> validChannel = new HashSet<string>{"BE", "FE", "QA", "Urgent"};

            // Regular expression to matchH tags enclosed in square brackets
            Regex regex = new Regex(@"\[(.*?)\]");
            MatchCollection matches = regex.Matches(title);

            List<String> channels = new List<string>();

            // Iterate through the matches and filter valid channels
            foreach(Match match in matches){
                string tag = match.Groups[1].Value;
                if(validChannel.Contains(tag)){
                    channels.Add(tag);
                }
            }
           return channels;
        }
        static void DisplayOutput(List<string> channels){
            if(channels.Count > 0) {
                Console.WriteLine("📢 Receive channels: " + string.Join(", ", channels));
            }
            else{
                Console.WriteLine("🚨No valid notification channels found. Please check your input! 🚨");
            }
            Console.WriteLine();
        }
        
    }

}