using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DogHouseApi.Models
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DogBreed
    {
        Affenpinscher,
        [EnumMember(Value = "Afghan Hound")]
        Afghan_Hound,
        [EnumMember(Value = "Airedale Terrier")]
        Airedale_Terrier,
        Akita,
        [EnumMember(Value = "Alaskan Malamute")]
        Alaskan_Malamute,
        [EnumMember(Value = "American Staffordshire Terrier")]
        American_Staffordshire_Terrier,
        [EnumMember(Value = "American Water Spaniel")]
        American_Water_Spaniel,
        [EnumMember(Value = "Australian Shepherd")]
        Australian_Shepherd,
        [EnumMember(Value = "Australian Terrier")]
        Australian_Terrier,
        Basenji,
        [EnumMember(Value = "Basset Hound")]
        Basset_Hound,
        Beagle,
        [EnumMember(Value = "Bernese Mountain Dog")]
        Bernese_Mountain_Dog,
        [EnumMember(Value = "Bichon Frise")]
        Bichon_Frise,
        Bloodhound,
        [EnumMember(Value = "Border Collie")]
        Border_Collie,
        [EnumMember(Value = "Border Terrier")]
        Border_Terrier,
        Borzoi,
        [EnumMember(Value = "Boston Terrier")]
        Boston_Terrier,
        Boxer,
        Briard,
        Brittany,
        Bulldog,
        Bullmastiff,
        Chihuahua,
        [EnumMember(Value = "Chinese Sharpei")]
        Chinese_Sharpei,
        [EnumMember(Value = "Chow Chow")]
        Chow_Chow,
        [EnumMember(Value = "Cocker Spaniel")]
        Cocker_Spaniel,
        Collie,
        Cockapoo,
        Dachshund,
        Dalmatian,
        [EnumMember(Value = "Doberman Pinscher")]
        Doberman_Pinscher,
        [EnumMember(Value = "English Setter")]
        English_Setter,
        Foxhound,
        [EnumMember(Value = "French Bulldog")]
        French_Bulldog,
        [EnumMember(Value = "German Shepherd")]
        German_Shepherd,
        [EnumMember(Value = "Golden Retriever")]
        Golden_Retriever,
        [EnumMember(Value = "Great Dane")]
        Great_Dane,
        Greyhound,
        [EnumMember(Value = "Irish Setter")]
        Irish_Setter,
        [EnumMember(Value = "Jack Russell Terrier")]
        Jack_Russell_Terrier,
        Keeshond,
        Komondor,
        Kuvasz,
        [EnumMember(Value = "Labrador Retriever")]
        Labrador_Retriever,
        Maltese,
        Mastiff,
        Newfoundland,
        Otterhound,
        Papillon,
        Pekingese,
        Pointer,
        Pomeranian,
        Poodle,
        Pug,
        Puli,
        [EnumMember(Value = "Rhodesian Ridgeback")]
        Rhodesian_Ridgeback,
        Rottweiler,
        [EnumMember(Value = "Saint Bernard")]
        Saint_Bernard,
        Saluki,
        Samoyed,
        Schipperke,
        Schnauzer,
        [EnumMember(Value = "Shetland Sheepdog")]
        Shetland_Sheepdog,
        [EnumMember(Value = "Shih Tzu")]
        Shih_Tzu,
        Spitz,
        Terrier,
        Vizsla,
        Weimaraner,
        Whippet,
        [EnumMember(Value = "Yorkshire Terrier")]
        Yorkshire_Terrier
    }
}
