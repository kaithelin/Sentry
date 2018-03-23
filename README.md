# Build

This is the main repository for the Dolittle Build system

## Cloning

This repository has sub modules, clone it with:

```shell
$ git clone --recursive <repository url>
```

If you've already cloned it, you can get the submodules by doing the following:

```shell
$ git submodule update --init --recursive
```

## Building

All the build things are from a submodule.
To build, run one of the following:

Windows:

```shell
$ Build\build.cmd
```

Linux / macOS

```shell
$ Build\build.sh
```
## Visual Studio

You can open the `.sln` file in the root of the repository and just build directly.

## VSCode

From the `Build` submdoule there is also a .vscode folder that gets a symbolic link for the root. This means you can open the
root of the repository directly in Visual Studio Code and start building. There are quite a few build tasks, so click F1 and type "Run Tasks" and select the "Tasks: Run Tasks"
option and then select the build task you want to run. It is folder sensitive and will look for the nearest `.csproj` file based on the file you have open.
If it doesn't find it, it will pick the `.sln` file instead.

## Environment

To set the development environment for ASP.NET Core, set the following environment variable before running

```shell
$ export ASPNETCORE_ENVIRONMENT=Development
```

## Kubernetes API details


https://developer.ibm.com/recipes/tutorials/service-accounts-and-auditing-in-kubernetes/
https://kubernetes.io/docs/tasks/configure-pod-container/configure-service-account/
https://kubernetes.io/docs/admin/service-accounts-admin/
https://kubernetes.io/docs/admin/authentication/

https://docs.microsoft.com/en-us/azure/storage/files/storage-how-to-use-files-linux


```shell
$ mkdir ~/MiniKubeData
$ minikube mount ~/MiniKubeData:/data
```



