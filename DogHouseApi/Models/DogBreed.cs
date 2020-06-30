using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DogHouseApi.Models
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DogBreed
    {
        [EnumMember(Value = "German Shepherd")]
        German_Shepherd,
        Bulldog,
        Poodle,
        [EnumMember(Value = "Labrador Retriever")]
        Labrador_Retriever,
        [EnumMember(Value = "Golden Retriever")]
        Golden_Retriever,
        Beagle,
        Dachshund,
        Chihuahua,
        Greyhound,
        Cockapoo,
        Pomeranian,
        Corgi,
        Mastiff,
        Schnauzer
    }
}
