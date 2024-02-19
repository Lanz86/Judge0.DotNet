using System.Text.Json.Serialization;
using Judge0.DotNet.Extensions;

namespace Judge0.DotNet.Models.Submissions
{
    public class Submission
    {
        public Submission(string sourceCode, int languageId)
        {
            SourceCode = sourceCode;
            LanguageId = languageId;
        }

        /// <summary>
        /// Program’s source code.
        ///  No default. This attribute is required for single-file programs.
        /// </summary>
        [JsonPropertyName("source_code")]
        public string SourceCode { get; private set; } // Required

        /// <summary>
        ///Language ID. No default. This attribute is required.
        /// </summary>
        [JsonPropertyName("language_id")]
        public int LanguageId { get; }

        /// <summary>
        /// Options for the compiler (i.e., compiler flags). Default is null.
        /// </summary>
        [JsonPropertyName("compiler_options")]
        public string? CompilerOptions { get; set; } = null;

        /// <summary>
        ///Command line arguments for the program. Default is null.
        /// </summary>
        [JsonPropertyName("command_line_arguments")]
        public string? CommandLineArguments { get; set; } = null;

        /// <summary>
        ///Input for program. Default is null. Program won’t receive anything to standard input. 
        /// </summary>
        [JsonPropertyName("stdin")]
        public string? Stdin { get; set; } = null;

        /// <summary>
        /// Expected output of program. Used when you want to compare with stdout. Default is null.
        /// </summary>
        [JsonPropertyName("expected_output")]
        public string? ExpectedOutput { get; set; } = null;

        /// <summary>
        /// Default runtime limit for every program in seconds. Depends on configuration.
        /// </summary>
        [JsonPropertyName("cpu_time_limit")]
        public float? CpuTimeLimit { get; set; } = null;

        /// <summary>
        ///"Extra time before killing the program when time limit is exceeded. Depends on configuration.
        /// </summary>
        [JsonPropertyName("cpu_extra_time")]
        public float? CpuExtraTime { get; set; } = null;

        /// <summary>
        /// Limit wall-clock time in seconds. Depends on configuration.
        /// </summary>
        [JsonPropertyName("wall_time_limit")]
        public float? WallTimeLimit { get; set; } = null;

        /// <summary>
        /// Limit address space of the program in kilobytes. Depends on configuration.
        /// </summary>
        [JsonPropertyName("memory_limit")]
        public float? MemoryLimit { get; set; } = null;

        /// <summary>
        /// Limit process stack in kilobytes. Depends on configuration.
        /// </summary>
        [JsonPropertyName("stack_limit")]
        public int? StackLimit { get; set; } = null;

        /// <summary>
        /// Maximum number of processes and/or threads program can create. Depends on configuration.
        /// </summary>
        [JsonPropertyName("max_processes_and_or_threads")]
        public int? MaxProcessesAndOrThreads { get; set; } = null;

        /// <summary>
        /// If true then cpu_time_limit will be used as per process and thread. Depends on configuration.
        /// </summary>
        [JsonPropertyName("enable_per_process_and_thread_time_limit")]
        public bool? EnablePerProcessAndThreadTimeLimit { get; set; } = null;

        /// <summary>
        /// If true then memory_limit will be used as per process and thread. Depends on configuration.
        /// </summary>
        [JsonPropertyName("enable_per_process_and_thread_memory_limit")]
        public bool? EnablePerProcessAndThreadMemoryLimit { get; set; } = null;

        /// <summary>
        /// Limit file size created or modified by the program in kilobytes. Depends on configuration.
        /// </summary>
        [JsonPropertyName("max_file_size")]
        public int? MaxFileSize { get; set; } = null;

        /// <summary>
        /// If true standard error will be redirected to standard output. Depends on configuration.
        /// </summary>
        [JsonPropertyName("redirect_stderr_to_stdout")]
        public bool RedirectStderrToStdout { get; set; }

        /// <summary>
        /// If true program will have network access. Depends on configuration.
        /// </summary>
        [JsonPropertyName("enable_network")]
        public bool? EnableNetwork { get; set; } = null;

        /// <summary>
        /// Run each program number_of_runs times and take average of time and memory. Depends on configuration.
        /// </summary>
        [JsonPropertyName("number_of_runs")]
        public int? NumberOfRuns { get; set; } = null;

        /// <summary>
        /// Additional files in Base64 Encoded String. This attribute is required for multi-file programs. Default is null.
        /// </summary>
        [JsonPropertyName("additional_files")]
        public string? AdditionalFiles { get; set; } = null;

        /// <summary>
        /// URL on which Judge0 will issue PUT request after submission. Default is null.
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string? CallbackUrl { get; set; } = null;

        public Task ToBase64Async(CancellationToken cancellationToken = default) 
        {
            Stdin = Stdin.ToBase64();
            SourceCode = SourceCode.ToBase64()??string.Empty;
            ExpectedOutput = ExpectedOutput.ToBase64();
            return Task.CompletedTask;
        }
    }
}
