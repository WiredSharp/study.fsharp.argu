#load @".paket/load/netcoreapp3.1/Argu.fsx"

open Argu

/// 
/// Now with subcommands
/// <see href="https://fsprojects.github.io/Argu/tutorial.html"/>
/// 

[<CliPrefix(CliPrefix.Dash)>]
type CleanArgs =
    | D
    | F
    | X
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | D -> "Remove untracked directories in addition to untracked files"
            | F -> "Git clean will refuse to delete files or directories unless given -f."
            | X -> "Remove only files ignored by Git."
and CommitArgs =
    | Amend
    | [<AltCommandLine("-p")>] Patch
    | [<AltCommandLine("-m")>] Message of msg:string
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Amend -> "Replace the tip of the current branch by creating a new commit."
            | Patch -> "Use the interactive patch selection interface to chose which changes to commit."
            | Message _ -> "Use the given <msg> as the commit message. "
and GitArgs =
    | Version
    | [<AltCommandLine("-v")>] Verbose
    | [<CliPrefix(CliPrefix.None)>] Clean of ParseResults<CleanArgs>
    | [<CliPrefix(CliPrefix.None)>] Commit of ParseResults<CommitArgs>
with
    interface IArgParserTemplate with
        member this.Usage =
            match this with
            | Version -> "Prints the Git suite version that the git program came from."
            | Verbose -> "Print a lot of output to stdout."
            | Clean _ -> "Remove untracked files from the working tree."
            | Commit _ -> "Record changes to the repository."
            
let parserGit = ArgumentParser.Create<GitArgs>(programName = "git.exe")