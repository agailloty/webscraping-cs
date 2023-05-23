# Job Data Extraction and Serialization

This project showcases a C# code snippet that demonstrates the extraction of job information from HTML documents using the HtmlAgilityPack library. The extracted data is then serialized into both CSV and JSON formats for further analysis and integration with other systems. 

## Prerequisites

To run this project, ensure that you have the following:

- .NET SDK (version 7.0.0 or higher)
- HtmlAgilityPack library

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/agailloty/webscraping-cs.git
   ```

2. Navigate to the project directory:

   ```bash
   cd webscraping-cs
   ```

3. Restore the NuGet packages:

   ```bash
   dotnet restore
   ```

## Usage

1. Place the HTML files containing job information in the "files" directory within the project.

2. Open the `Program.cs` file and locate the `Main` method.

3. Within the `Main` method, ensure that the file encoding matches your HTML file encoding. Modify the following line if necessary:

   ```csharp
   doc.Load(file, Encoding.UTF8, false);
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

5. The program will extract job information from each HTML file in the "files" directory, serialize it into CSV and JSON formats, and save the results as "jobs.csv" and "jobs.json", respectively.

## Configuration

The project does not require any additional configuration. However, you can modify the following aspects according to your needs:

- File path and directory:
  - The "files" directory is used to store the input HTML files. You can change the directory name or location by modifying the `Directory.GetFiles("files")` line in the `Main` method.
  - The output CSV file name and path can be customized in the `File.WriteAllLines("jobs.csv", ...)` line.
  - The output JSON file name and path can be customized in the `Persist("jobs.json", ...)` line.

## Dependencies

This project utilizes the following dependencies:

- HtmlAgilityPack (version X.X.X): A library for parsing and manipulating HTML documents. It is used for extracting job information from HTML files.

## License

This project is licensed under the [MIT License](LICENSE).

## Contributing

Contributions to this project are welcome. Feel free to open issues or submit pull requests to suggest improvements or bug fixes.

## Contact

For any questions or inquiries, please contact [your-name](mailto:agailloty@gmail.com).
