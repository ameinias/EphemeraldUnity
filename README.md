# EphemeraldUnity

A C# port of [Tracery](http://tracery.io/), a text generation library/language/tool originally designed by [Kate Compton](http://www.galaxykate.com/). Primarily intended to be used within the [Unity](https://unity3d.com/) engine.

This project adds the [ephemeral](https://github.com/martinpi/ephemeral) extensions of Tracery to [Max Kreminski](https://mkremins.github.io)'s C#/Unity port.

## Installation

Download the `Source` directory from this repository and drop it into your Unity project's `Assets` folder. Alternatively you can download the `Sample Project` in this repository and arrive at the same point.

## Usage

### Create a `Grammar`

No matter what you're trying to do, the first step will almost always be to get your hands on a `Grammar` object. There are a few different ways to do this.

#### Method 1: Use the GUI editor

In the Unity editor, select a game object to which you'd like to attach a grammar. Then, in the inspector, click `Add Component > Scripts > Tracery Grammar`. A GUI editor for the grammar will appear. Here, you can add and remove rules, edit existing rules, and test the grammar by viewing examples of generated strings.

Once you're satisfied with your grammar, you can access it in your scripts as follows:

```C#
GameObject go = GameObject.Find("foo"); // the GameObject to which you attached the TraceryGrammar script
Grammar grammar = go.GetComponent<TraceryGrammar>().Grammar;
```

#### Method 2: Load from Ephemerald

Add the Ephemerald grammar file containing your serialized grammar to the `Assets/Resources` directory within your Unity project. Then you can access it in your scripts as follows:

```C#
TextAsset jsonFile = Resources.Load("grammar") as TextAsset; // assuming the file is at Assets/Resources/grammar.json
Grammar grammar = Grammar.LoadFromCCC(cccFile);
```

You can also use `Grammar.LoadFromCCC(string cccString)` to load a grammar directly from an Ephemerald string.

#### Method 3: Load from JSON

Add the JSON file containing your serialized grammar to the `Assets/Resources` directory within your Unity project. Then you can access it in your scripts as follows:

```C#
TextAsset jsonFile = Resources.Load("grammar") as TextAsset; // assuming the file is at Assets/Resources/grammar.json
Grammar grammar = Grammar.LoadFromJSON(jsonFile);
```

You can also use `Grammar.LoadFromJSON(string jsonString)` to load a grammar directly from a JSON string.

#### Method 4: Write a script

In a C# script, you can create a `Grammar` object directly using the public constructor. Then you can programmatically populate it with rules using the `PushRules` method:

```C#
Grammar grammar = new Grammar();
grammar.PushRules("origin", new string[]{"Hello, #name#!"});
grammar.PushRules("name", new string[]{"Max", "world"});
```

...but note that this approach can get unwieldy pretty quickly, especially for more complicated grammars.

### Generate strings

Once you've acquired a `Grammar` object, you can use the `Flatten` method to generate a fully expanded string from an initial base string. For example:

```C#
string expanded = grammar.Flatten("#origin#"); // assuming the grammar has a rule named 'origin'
```

EphemeraldUnity is still incomplete, but you should be able to use most of the basic syntax described in the [Tracery tutorial](http://www.crystalcodepalace.com/traceryTut.html).

### Make EphemeraldUnity deterministic

[Much like Tracery itself](https://github.com/galaxykate/tracery/tree/tracery2#making-tracery-deterministic), you can make TracerySharp deterministic by setting `Tracery.Rng` to an instance of `System.Random` [constructed with a specified seed](https://msdn.microsoft.com/en-us/library/ctssatww(v=vs.110).aspx):

```C#
Tracery.Rng = new System.Random(42); // replace 42 with whatever seed you want
```

## Credits

[Martin Pichlmair](http://vertical-progress.net) is currently working on extending this port of Tracery. He's the author of the highly unpopular and obscure [Ephemerald](https://martinpi.itch.io/ephemerald) editor that allows nicer Tracery editing than fumbling around with JSON.

[Tracery](http://tracery.io/) was originally designed and developed by [Kate Compton](http://www.galaxykate.com/).

[Max Kreminski](http://mkremins.github.io/) ported it to C# for use with Unity.

JSON parsing is done with [SimpleJSON](http://wiki.unity3d.com/index.php/SimpleJSON). SimpleJSON was originally developed by Bunny83 and later modified by oPless.
