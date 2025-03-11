// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.Json;
using MedicationJSON.Models;
using NJsonSchema;
using Semver;

var schema = JsonSchema.FromType<Information>();

var SampleData = new Information()
{
    Version = new Semver.SemVersion(1, 0, 0, [new PrereleaseIdentifier(1)]).ToString(),
    About = """
    Informations about continous rate infusions based on the DIVI recommendations.
    These informations are used in the PerfuRate Application available for Android.
    Source: "Empfehlungen zu Standardkonzentrationen für die kontinuierliche Infusion auf Intensivstationen"
    """,
    Author = "Medist.org",
    Disclaimer = """
    The information is intended for medical professionals. While care has been taken to
    ensure that the provided information is correct, they are for informational purpose only.
    Any information should be used with your own clinical judgement. It cannot be guaranteed
    that the provided information covers all possible uses or cases.
    Any information provided is used solely at your own risk.
    """,
    LastUpdated = DateTime.Now,
    Website = new Uri("https://medist.org"),
    MedicationData = []
};

SampleData.MedicationData.Add(new()
{
    Name = "Alteplase",
    Categories = ["Anticoagulation"],
    Aliases = ["Actilyse", "rt-PA", "t-PA"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 50},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Amiodarone",
    Categories = ["Antiarrhythm"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 1050},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Agatroban",
    Categories = ["Anticoagulation"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 50},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Clonidine",
    Categories = ["Vasodilator"],
    Preparations = [new (){
        Dose = new(){Unit = "µg", Value = 750},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Dexmedetomidine",
    Categories = ["Hypnotic"],
    Preparations = [new (){
        Dose = new(){Unit = "µg", Value = 400},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Dihydralazine",
    Categories = ["Vasodilator"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 50},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Dobutamine",
    Categories = ["Inodilatator"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 250},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Epinephrine",
    Aliases = ["Adrenaline"],
    Categories = ["Epinephrine"],
    Preparations = [
        new (){
            Dose = new(){Unit = "mg", Value = 1},
            Volume = new(){Unit = "ml", Value = 50}
        },
        new (){
            Dose = new(){Unit = "mg", Value = 5},
            Volume = new(){Unit = "ml", Value = 50}
        },
        new (){
            Dose = new(){Unit = "mg", Value = 10},
            Volume = new(){Unit = "ml", Value = 50}
        }
    ]
});

SampleData.MedicationData.Add(new()
{
    Name = "Norepinephrine",
    Aliases = ["Noradrenalin"],
    Categories = ["Norepinephrine"],
    Preparations = [
        new (){
            Dose = new(){Unit = "mg", Value = 1},
            Volume = new(){Unit = "ml", Value = 50}
        },
        new (){
            Dose = new(){Unit = "mg", Value = 5},
            Volume = new(){Unit = "ml", Value = 50}
        },
        new (){
            Dose = new(){Unit = "mg", Value = 10},
            Volume = new(){Unit = "ml", Value = 50}
        },
        new (){
            Dose = new(){Unit = "mg", Value = 20},
            Volume = new(){Unit = "ml", Value = 50}
        }
    ]
});

SampleData.MedicationData.Add(
    new()
    {
        Name = "Furosemide",
        Preparations = [
            new(){
                Dose = new(){Unit = "mg", Value = 500},
                Volume = new(){Unit = "ml", Value = 50}
            }
        ]
    }
);

SampleData.MedicationData.Add(new()
{
    Name = "Glyceroltrinitrate",
    Aliases = ["Nitroglycerine"],
    Categories = ["Vasodilator"],
    Preparations = [
        new(){
            Dose = new(){Unit = "mg", Value = 50},
            Volume = new(){Unit = "ml", Value = 50}
        }
    ]
});

SampleData.MedicationData.Add(new()
{
    Name = "Midazolam",
    Categories = ["Benzodiazepine"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 100},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

SampleData.MedicationData.Add(new()
{
    Name = "Propofol",
    Categories = ["Hypnotic"],
    Preparations = [new (){
        Dose = new(){Unit = "mg", Value = 1000},
        Volume = new(){Unit = "ml", Value = 50}
    }]
});

var options = new JsonSerializerOptions()
{
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault | System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
};
var data = JsonSerializer.Serialize(SampleData, options);
var validationResult = schema.Validate(data);

Debug.Assert(validationResult.Count() == 0);

using (StreamWriter outputFile = new StreamWriter(Path.Combine("InformationSchema.json")))
{
    outputFile.Write(schema.ToJson());
}

using (StreamWriter outputFile = new StreamWriter(Path.Combine("MedistData.json")))
{
    outputFile.Write(data);
}

Console.WriteLine($"Done, finished with {validationResult.Count()} validation errors.");