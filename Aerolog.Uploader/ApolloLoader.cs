using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Aerolog.Core;
using Aerolog.Engines;

namespace Aerolog.Uploader.SeriesLoader
{
    public class ApolloLoader : ILoader
    {
        private readonly ISeriesEngine _seriesEngine;
        private readonly IMissionEngine _missionEngine;
        private readonly ILogEngine _logEngine;
        public ApolloLoader(ISeriesEngine seriesEngine, IMissionEngine missionEngine, ILogEngine logEngine)
        {
            _seriesEngine = seriesEngine;
            _missionEngine = missionEngine;
            _logEngine = logEngine;
        }

        public async Task Populate()
        {
            var basePath = @"R:\Code\aerolog\Data\Apollo";
            var series = await BaseLoaderHelpers.GetOrCreateSeries(_seriesEngine, "Apollo", "https://storage.googleapis.com/aerolog-data/apollo/series.jpg");
            var missionDataList = new List<MissionData>
            {
                new MissionData
                {
                    Title = "Apollo 1",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo1/apollo1.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 7",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo7/apollo7.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 8",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo8/apollo8.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 9",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo9/apollo9.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 10",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo10/apollo10.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 11",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo11/apollo11.jpg",
                    DataPath = "apollo11.txt",
                    MissionStart = new DateTime(1969, 7, 16, 13, 32, 00, DateTimeKind.Utc),
                    Speakers = new Dictionary<string, string>()
                    {
                        {"CDR","Neil A. Armstrong"},
                        {"CMP","Michael Collins"},
                        {"LMP","Edwin E. ALdrin, Jr."},
                        {"SC","Unidentifiable crewmember"},
                        {"MS","Multiple (simultaneous) speakers"},
                        {"LCC","Launch Control Center"},
                        {"CC","Capsule Communicator (CAP COMM)"},
                        {"F","Flight Director"},
                        {"CT","Communications Technician (COMM TECH)"},
                        {"HORNET","USS Hornet"},
                        {"R","Recovery helicopter"},
                        {"AB","Air Boss"},
                        {"SWIM 1", "Swim 1" },
                        {"MSFN", "" },
                        {"CDF", "" },
                        {"PRESIDENT NIXON", "" }
                    },
                },
                new MissionData
                {
                    Title = "Apollo 12",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo12/apollo12.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 13",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo13/apollo13.jpg",
                    // DataPath = "apollo13.txt",
                    MissionStart = new DateTime(1970, 4, 11, 19, 13, 00, DateTimeKind.Utc),
                    Speakers = new Dictionary<string, string>()
                    {
                        { "CDR", "James A. Lovell, Jr." },
                        { "CMP", "John L. Swigert, Jr."},
                        { "LMP", "Fred W. Haise, Jr." },
                        {"SC","Unidentifiable crewmember"},
                        {"MS","Multiple (simultaneous) speakers"},
                        {"CC","Capsule Communicator (CAP COMM)"},
                        {"LCC","Launch Control Center"},
                        {"F","Flight Director"},
                        {"S", "Surgeon" },
                        {"AB","Air Boss"},
                        {"CT","Communications Technician (COMM TECH)"},
                        {"IWO", "USS Iwo Jima" },
                        {"P-*", "Photographic helicopters" },
                        {"R-*", "Recovery helicopters" }
                    }
                },
                new MissionData
                {
                    Title = "Apollo 14",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo14/apollo14.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 15",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo15/apollo15.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 16",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo16/apollo16.jpg"
                },
                new MissionData
                {
                    Title = "Apollo 17",
                    ImagePath = "https://storage.googleapis.com/aerolog-data/apollo/apollo17/apollo17.jpg"
                },
            };

            foreach (var missionData in missionDataList)
            {
                var mission = await BaseLoaderHelpers.GetOrCreateMission(_missionEngine, missionData.Title, missionData.ImagePath, series.Id);

                if (!string.IsNullOrWhiteSpace(missionData.DataPath))
                {
                    await _logEngine.DeleteAllLogsByMissionId(mission.Id);
                    var fullDataPath = Path.Combine(basePath, missionData.DataPath);
                    var lines = await System.IO.File.ReadAllLinesAsync(fullDataPath);
                    var sb = new StringBuilder();
                    var logs = new List<Log>();
                    var index = 0;
                    var logRegex = GetLogRegex(missionData);
                    while (!Regex.IsMatch(lines[index], logRegex))
                    {
                        WriteLogProgress(index, lines.Length);
                        index++;
                    }

                    while (index < lines.Length)
                    {
                        var line = lines[index];
                        WriteLogProgress(index, lines.Length);
                        if (string.IsNullOrWhiteSpace(line))
                        {

                            index++;
                            continue;
                        }
                        var match = Regex.Match(line, logRegex);
                        if (match.Success)
                        {
                            index++;
                            while (index < lines.Length && !Regex.IsMatch(lines[index], logRegex))
                            {
                                if (IsValidLine(lines[index]))
                                {

                                    sb.AppendLine(lines[index]);
                                }
                                index++;
                            }
                            try
                            {
                                var stampParts = match.Groups["stamp"].Value.Split(" ");
                                var timestamp = missionData.MissionStart
                                    .AddDays(int.Parse(stampParts[0]))
                                    .AddHours(int.Parse(stampParts[1]))
                                    .AddMinutes(int.Parse(stampParts[2]))
                                    .AddSeconds(int.Parse(stampParts[3]));
                                var log = new Log
                                {
                                    SpeakerName = match.Groups["speaker"].Value,
                                    Timestamp = timestamp,
                                    MissionId = mission.Id,
                                    SeriesId = series.Id,
                                    Text = sb.ToString().Trim().Replace("\n", " "),
                                };
                                await _logEngine.Save(log);
                                sb.Clear();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            index++;
                        }
                    }
                }

                if (missionData.Speakers != null)
                {
                    mission.Speakers = missionData.Speakers.Select(kvp => new Speaker
                    {
                        Label = kvp.Key,
                        Name = kvp.Value
                    }).ToList();
                }

                await _missionEngine.Save(mission);
            }
        }

        private bool IsValidLine(string line)
        {
            return !string.IsNullOrWhiteSpace(line) &&
                !Regex.IsMatch(line, "\\(GOSS NET \\d\\)") &&
                !line.Contains("END OF TAPE") &&
                !line.Contains("REST PERIOD - NO COMMUNICATIONS") &&
                !line.Contains("BEGIN LUNAR REV") &&
                !line.Contains("*** Three asterisks") &&
                !Regex.IsMatch(line, "APOLLO 11 .* VOICE TRANSCRIPTION") &&
                !Regex.IsMatch(line, "\\(REV *\\d+\\)");
        }

        private string GetLogRegex(MissionData data)
        {
            var speakerNames = string.Join("|", data.Speakers.Keys);
            var dhmsFormat = "(.. .. .. ..)";
            var hmsFormat = "(...:..:..)";
            var logRegex = $"^(?<stamp>{dhmsFormat}|{hmsFormat}) (?<speaker>{speakerNames})";
            return logRegex;
        }

        private void WriteLogProgress(int current, int total)
        {
            var percent = Math.Round(current / (decimal)total, 4) * 100;
            Console.Write($"\rProcessing logs: {percent}% \t");
        }
    }
}
