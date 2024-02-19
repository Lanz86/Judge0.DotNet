using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Systems;

public class SystemInfo
{
    [JsonPropertyName("Architecture")]
    public string Architecture { get; set; }

    [JsonPropertyName("CPU op-mode(s)")]
    public string CPUopmodes { get; set; }

    [JsonPropertyName("Byte Order")]
    public string ByteOrder { get; set; }

    [JsonPropertyName("CPU(s)")]
    public string CPUs { get; set; }

    [JsonPropertyName("On-line CPU(s) list")]
    public string OnlineCPUslist { get; set; }

    [JsonPropertyName("Thread(s) per core")]
    public string Threadspercore { get; set; }

    [JsonPropertyName("Core(s) per socket")]
    public string Corespersocket { get; set; }

    [JsonPropertyName("Socket(s)")]
    public string Sockets { get; set; }

    [JsonPropertyName("NUMA node(s)")]
    public string NUMAnodes { get; set; }

    [JsonPropertyName("Vendor ID")]
    public string VendorID { get; set; }

    [JsonPropertyName("CPU family")]
    public string CPUfamily { get; set; }

    [JsonPropertyName("Model")]
    public string Model { get; set; }

    [JsonPropertyName("Model name")]
    public string Modelname { get; set; }

    [JsonPropertyName("Stepping")]
    public string Stepping { get; set; }

    [JsonPropertyName("CPU MHz")]
    public string CPUMHz { get; set; }

    [JsonPropertyName("CPU max MHz")]
    public string CPUmaxMHz { get; set; }

    [JsonPropertyName("CPU min MHz")]
    public string CPUminMHz { get; set; }

    [JsonPropertyName("BogoMIPS")]
    public string BogoMIPS { get; set; }

    [JsonPropertyName("Virtualization")]
    public string Virtualization { get; set; }

    [JsonPropertyName("L1d cache")]
    public string L1dcache { get; set; }

    [JsonPropertyName("L1i cache")]
    public string L1icache { get; set; }

    [JsonPropertyName("L2 cache")]
    public string L2cache { get; set; }

    [JsonPropertyName("L3 cache")]
    public string L3cache { get; set; }

    [JsonPropertyName("NUMA node0 CPU(s)")]
    public string NUMAnode0CPUs { get; set; }

    [JsonPropertyName("Mem")]
    public string Mem { get; set; }

    [JsonPropertyName("Swap")]
    public string Swap { get; set; }
}