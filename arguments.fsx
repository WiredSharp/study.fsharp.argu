#r ".paket/load/netcoreapp3.1/Argu.fsx"

open Argu

type CliArguments =
    | [<Mandatory>] WorkingDirectory of path: string
    | Listener of host: string * port: int
    | Data of base64: byte []
    | Port of tcp_port: int
    | LogLevel of level: int
    | Detach
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | WorkingDirectory _ -> "specify a working directory."
            | Listener _ -> "specify a listener (hostname : port)."
            | Data _ -> "binary data in base64 encoding."
            | Port _ -> "specify a primary port."
            | LogLevel _ -> "set the log level."
            | Detach _ -> "detach daemon from console."

let parser = ArgumentParser.Create<CliArguments>(programName = "gadget.exe")
