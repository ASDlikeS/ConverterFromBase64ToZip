# Base64 to ZIP Converter

A simple tool that converts a Base64-encoded text file back into a ZIP archive.

## What it does

- Reads a text file that contains a Base64 string (ASCII)
- Decodes it into binary data
- Saves it as `output.zip`

Base64 is used to send binary data (like a ZIP archive) over the internet via text-based protocols (JSON, HTTP, etc.). This utility reverses the process.

## How to use

1. Place your Base64 file (e.g., `base64.txt`) in the same folder as the program.
2. Run the executable:

```cmd
Base64ToZip.exe
```

3. The `output.zip` file will be created.

You can also specify a custom input file:

```cmd
Base64ToZip.exe mydata.txt
```

## Requirements

- Windows
- .NET 8+ (or use the self-contained version)

## Example

Input file (`base64.txt`):

```text
UEsDBBQAAAAIA...
```

Output: `output.zip` – a valid ZIP archive containing the original files.

## Build

```cmd
dotnet publish -c Release -r win-x64 -o publish --self-contained true
```

> **Note:** Useful for extracting archived data received via JSON payloads.