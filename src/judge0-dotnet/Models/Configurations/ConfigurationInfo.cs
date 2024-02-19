using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Configurations;

public class ConfigurationInfo
{
    /// <summary>
    /// If enabled user can request to synchronously wait for submission result on submission create. 
    /// </summary>
    [JsonPropertyName("enable_wait_result")]
    public bool EnableWaitResult { get; set; } = true; 

    /// <summary>
    ///If enabled user can set compiler_options. 
    /// </summary>
    [JsonPropertyName("enable_compiler_options")]
    public bool EnableCompilerOptions { get; set; } = true; 

    /// <summary>
    ///Languages for which setting compiler options is allowed. Empty, i.e. for all languages it is allowed to set compiler options. 
    /// </summary>
    [JsonPropertyName("allowed_languages_for_compile_options")]
    public List<string> AllowedLanguagesForCompileOptions { get; set; } = new List<string>(); 

    /// <summary>
    /// If enabled user can set command_line_arguments.
    /// </summary>
    [JsonPropertyName("enable_command_line_arguments")]
    public bool EnableCommandLineArguments { get; set; } = true; 

    /// <summary>
    /// If enabled authorized user can delete a submission.
    /// </summary>
    [JsonPropertyName("enable_submission_delete")]
    public bool EnableSubmissionDelete { get; set; } = false; 

    /// <summary>
    /// Maximum number of submissions that can wait in queue.
    /// </summary>
    [JsonPropertyName("max_queue_size")]
    public int MaxQueueSize { get; set; } = 100; 

    /// <summary>
    /// Default runtime limit for every program (in seconds).
    /// </summary>
    [JsonPropertyName("cpu_time_limit")]
    public float CpuTimeLimit { get; set; } = 2; 

    /// <summary>
    ///When a time limit is exceeded, wait for extra time before killing the program. 
    /// </summary>
    [JsonPropertyName("cpu_extra_time")]
    public float CpuExtraTime { get; set; } = 0.5f; 

    /// <summary>
    /// Limit wall-clock time in seconds.
    /// </summary>
    [JsonPropertyName("wall_time_limit")]
    public float WallTimeLimit { get; set; } = 5; 

    /// <summary>
    /// Limit address space of the program in kilobytes.
    /// </summary>
    [JsonPropertyName("memory_limit")]
    public int MemoryLimit { get; set; } = 128000; 

    /// <summary>
    /// Limit process stack in kilobytes.
    /// </summary>
    [JsonPropertyName("stack_limit")]
    public int StackLimit { get; set; } = 64000; 

    /// <summary>
    /// Maximum number of processes and/or threads program can create.
    /// </summary>
    [JsonPropertyName("max_processes_and_or_threads")]
    public int MaxProcessesAndOrThreads { get; set; } = 60; 

    /// <summary>
    /// If true then cpu_time_limit will be used as per process and thread.
    /// </summary>
    [JsonPropertyName("enable_per_process_and_thread_time_limit")]
    public bool EnablePerProcessAndThreadTimeLimit { get; set; } = false; 

    /// <summary>
    /// If true then memory_limit will be used as per process and thread.
    /// </summary>
    [JsonPropertyName("enable_per_process_and_thread_memory_limit")]
    public bool EnablePerProcessAndThreadMemoryLimit { get; set; } = true; 

    /// <summary>
    /// Limit size of files created (or modified) by the program.
    /// </summary>
    [JsonPropertyName("max_file_size")]
    public int MaxFileSize { get; set; } = 1024; 

    /// <summary>
    /// If enabled user can set enable_network.
    /// </summary>
    [JsonPropertyName("allow_enable_network")]
    public bool AllowEnableNetwork { get; set; } = true; 

    /// <summary>
    ///If enabled program will have network access. 
    /// </summary>
    [JsonPropertyName("enable_network")]
    public bool EnableNetwork { get; set; } = true; 

    /// <summary>
    /// Run each program this many times and take average of time and memory.
    /// </summary>
    [JsonPropertyName("number_of_runs")]
    public int NumberOfRuns { get; set; } = 1;
    
    /// <summary>
    /// Maximum custom cpu_time_limit in seconds.
    /// </summary>
    [JsonPropertyName("max_cpu_time_limit")]
    public float MaxCpuTimeLimit { get; set; } = 15; 

    /// <summary>
    /// Maximum custom cpu_extra_time in seconds.
    /// </summary>
    [JsonPropertyName("max_cpu_extra_time")]
    public float MaxCpuExtraTime { get; set; } = 2; 

    /// <summary>
    /// Maximum custom wall_time_limit in seconds.
    /// </summary>
    [JsonPropertyName("max_wall_time_limit")]
    public float MaxWallTimeLimit { get; set; } = 20;

    /// <summary>
    ///  Maximum custom memory_limit in kilobytes.
    /// </summary>
    [JsonPropertyName("max_memory_limit")]
    public int MaxMemoryLimit { get; set; } = 256000;

    /// <summary>
    /// Maximum custom stack_limit in kilobytes.
    /// </summary>
    [JsonPropertyName("max_stack_limit")]
    public int MaxStackLimit { get; set; } = 128000; 

    /// <summary>
    /// Maximum custom max_processes_and_or_threads.
    /// </summary>
    [JsonPropertyName("max_max_processes_and_or_threads")]
    public int MaxMaxProcessesAndOrThreads { get; set; } = 120;  

    /// <summary>
    /// If false user won’t be able to set enable_per_process_and_thread_time_limit to true.
    /// </summary>
    [JsonPropertyName("allow_enable_per_process_and_thread_time_limit")]
    public bool AllowEnablePerProcessAndThreadTimeLimit { get; set; } = true;

    /// <summary>
    /// If false user won’t be able to set enable_per_process_and_thread_memory_limit to true.
    /// </summary>
    [JsonPropertyName("allow_enable_per_process_and_thread_memory_limit")]
    public bool AllowEnablePerProcessAndThreadMemoryLimit { get; set; } = true; 

    /// <summary>
    /// Maximum custom max_file_size in kilobytes.
    /// </summary>
    [JsonPropertyName("max_max_file_size")]
    public int MaxMaxFileSize { get; set; } = 4096; 

    /// <summary>
    /// Maximum custom number_of_runs.
    /// </summary>
    [JsonPropertyName("max_number_of_runs")]
    public int MaxNumberOfRuns { get; set; } = 20;
}
