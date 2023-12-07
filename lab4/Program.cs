using lab4;
using McMaster.Extensions.CommandLineUtils;

string LAB_PATH = Environment.CurrentDirectory;

var app = new CommandLineApplication
{
    Name = "run-labs",
    Description = "\nruns lab 1-3",
};

app.HelpOption(inherited: true);

app.Command("version", setVer => Console.WriteLine("Author: Maksym Prymachuk\nVersion: 1.0"));
app.Command("set-path", setPath =>
{
    var labPath = setPath.Option("-p|--path", "path", CommandOptionType.SingleValue);

    setPath.OnExecute(() => LAB_PATH = labPath.Value());
});

app.Command("run", setCmd =>
{
    setCmd.Description = "Set lab";
    var lab1 = setCmd.Command("lab1", runLab =>
    {
        var inputFilePath = runLab.Option("-i|--input", "input", CommandOptionType.SingleValue);
        var outputFilePath = runLab.Option("-o|--output", "output", CommandOptionType.SingleValue);

        runLab.OnExecute(() =>
        {
            if (inputFilePath.HasValue() && outputFilePath.HasValue())
            {
                labs.Lab1(inputFilePath.Value(), outputFilePath.Value());
            }
            else if (inputFilePath.HasValue())
            {
                labs.Lab1(inputFilePath: inputFilePath.Value(), labPath: LAB_PATH);
            }
            else if (outputFilePath.HasValue())
            {
                labs.Lab1(outputFilePath: outputFilePath.Value(), labPath: LAB_PATH);
            }
            else
            {
                labs.Lab1(labPath: LAB_PATH);
            }
        });
    });

    var lab2 = setCmd.Command("lab2", runLab =>
    {
        var inputFilePath = runLab.Option("-i|--input", "input", CommandOptionType.SingleValue);
        var outputFilePath = runLab.Option("-o|--output", "output", CommandOptionType.SingleValue);

        runLab.OnExecute(() =>
        {
            if (inputFilePath.HasValue() && outputFilePath.HasValue())
            {
                labs.Lab2(inputFilePath.Value(), outputFilePath.Value());
            }
            else if (inputFilePath.HasValue())
            {
                labs.Lab2(inputFilePath: inputFilePath.Value(), labPath: LAB_PATH);
            }
            else if (outputFilePath.HasValue())
            {
                labs.Lab2(outputFilePath: outputFilePath.Value(), labPath: LAB_PATH);
            }
            else
            {
                labs.Lab2(labPath: LAB_PATH);
            }
        });
    });

    var lab3 = setCmd.Command("lab3", runLab =>
    {
        var inputFilePath = runLab.Option("-i|--input", "input", CommandOptionType.SingleValue);
        var outputFilePath = runLab.Option("-o|--output", "output", CommandOptionType.SingleValue);

        runLab.OnExecute(() =>
        {
            if (inputFilePath.HasValue() && outputFilePath.HasValue())
            {
                labs.Lab3(inputFilePath.Value(), outputFilePath.Value());
            }
            else if (inputFilePath.HasValue())
            {
                labs.Lab3(inputFilePath: inputFilePath.Value(), labPath: LAB_PATH);
            }
            else if (outputFilePath.HasValue())
            {
                labs.Lab3(outputFilePath: outputFilePath.Value(), labPath: LAB_PATH);
            }
            else
            {
                labs.Lab3(labPath: LAB_PATH);
            }
        });
    });


    setCmd.OnExecute(() =>
    {

    });
});

app.OnExecute(() =>
{
    Console.WriteLine("\n\nSpecify a subcommand");
    app.ShowHelp();
    return 1;
});

return app.Execute(args);