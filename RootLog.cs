using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace RootLogging {

    public enum Severity {
        Trace, // Information that is valuable only for debugging.
        Debug, // Information that may be useful in development and debugging.
        Information, // Tracking the general flow of the app. Long term logging.
        Warning, // Abnormal or unexpected events. Errors that should be investigated.
        Error, // Errors and exceptions that cannot be handled.
        Critical // Failures that require immediate attention.
    }

    public static class RootLog {
        // FIELDS ~~~~~~~~~~
        private static List<LogItem> _items = new List<LogItem>();
        // CONSTRUCTORS ~~~~~~~~~~

        // DESTRUCTORS ~~~~~~~~~~

        // DELEGATES ~~~~~~~~~~

        // EVENTS ~~~~~~~~~~

        // ENUMS

        // INTERFACES ~~~~~~~~~~

        // PROPERTIES ~~~~~~~~~~

        // INDEXERS ~~~~~~~~~~

        // METHODS ~~~~~~~~~

/// <summary>
/// Log an event.
/// </summary>
/// <param name="message">A message associated with the event.</param>
/// <param name="severity">The severity of the event.</param>
/// <param name="category">An optional category for the event.</param>
        public static void Log(
            string message, 
            Severity severity = Severity.Debug, 
            string category = "General"
        ) {
            LogItem item = new LogItem(
                DateTime.Now, 
                severity, 
                category, 
                message
            );

            _items.Add(item);
            string logString =
                "@Frame " + Time.frameCount + ": " + 
                severity.ToString() + ", " + 
                category + ", \n" + 
                message;

            switch (severity) {
                case Severity.Critical:
                    Debug.LogError(logString);
                    break;
                case Severity.Debug:
                    Debug.Log(logString);
                    break;
                case Severity.Error:
                    Debug.LogError(logString);
                    break;
                case Severity.Information:
                    Debug.Log(logString);
                    break;
                case Severity.Trace:
                    Debug.Log(logString);
                    break;
                case Severity.Warning:
                    Debug.LogWarning(logString);
                    break;
            }
        }

/// <summary>
/// Dump the event log to a text file.
/// </summary>
/// <param name="target">Target path for the text file dump.</param>
        public static void ToFile(string target) {
            if (!File.Exists(target)) {
                StreamWriter sw = File.CreateText(target);
                try {
                    foreach(LogItem item in _items) {
                        sw.WriteLine(
                            item.time.Millisecond + ": " +
                            item.severity + ", " +
                            item.category + ", " +
                            item.message
                        );
                    }
                }
                finally {
                    if (sw != null)
                        sw.Dispose();
                }
            }
            else {
                File.Delete(target);
                ToFile(target);
            }
        }

/// <summary>
/// Dump the event log to a database. [Not implemented]
/// </summary>
        public static void ToDatabase() {
            throw new System.NotImplementedException();
        }

/// <summary>
/// Dump an event to a json file. [Not implemented]
/// </summary>
        public static void ToJSON() {
            throw new System.NotImplementedException();
        }

        // STRUCTS ~~~~~~~~~~
        private struct LogItem {
            public DateTime time;
            public Severity severity;
            public string category;
            public string message;

            public LogItem (
                DateTime time, 
                Severity severity, 
                string category, 
                string message
            ) {
                this.time = time;
                this.severity = severity;
                this.category = category;
                this.message = message;
            }
        }

        // PRIVATE CLASSES ~~~~~~~~~~
    }
}