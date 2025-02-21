using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using w4_assignment_ksteph.Inventories;

namespace w4_assignment_ksteph.FileIO.Json;

// The JsonInventoryConverter is used to turn json format into an Inventories Object automatically.
public class JsonInventoryConverter : JsonConverter<Inventory>
{
    public override Inventory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            throw new JsonException("ARRAYREADER: Value is null");
        } else if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("ARRAYREADER: Value is not an array.");
        }
        var itemSet = new List<string>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return InventorySerializer.DeserializeList(itemSet);
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                itemSet.Add(reader.GetString()!);
            }
            else
            {
                throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
            }
        }
        throw new JsonException($"ARRAYREADER: Unexpected token type {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, Inventory inventory, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (string item in InventorySerializer.SerializeList(inventory)!)
        {
            writer.WriteStringValue(item);
        }

        writer.WriteEndArray();
    }

    // The JsonInventoryConverter is used to turn imported strings with "item1|item2|item3" format imported via json into
    // inventories automatically.  This converter was used when the json structure only supported string values.  The json
    // structure now accepts string arrays for the inventory and therefore this class is currently unused and is obsolete
    // indefinitely.

    //[Obsolete]
    // Turns an imported string into an inventory.
    //public override Inventory? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //{
    //    return InventorySerializer.Deserialize(reader.GetString()!);
    //}

    //[Obsolete]
    // turns an exported inventory into a string.
    //public override void Write(Utf8JsonWriter writer, Inventory inventory, JsonSerializerOptions options)
    //{
    //    writer.WriteStringValue(InventorySerializer.Serialize(inventory));
    //}
}
