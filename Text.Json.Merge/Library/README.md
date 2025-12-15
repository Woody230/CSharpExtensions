![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Text.Json.Merge)](https://www.nuget.org/packages/Woody230.Text.Json.Merge)

# Text.Json.Merge

Merging of JSON nodes from the System.Text.Json namespace.

## Extensions

| Method | Description |
| --- | --- |
| JsonNode? Merge(this JsonNode @this, JsonNode? other) | Combines the contents of the this node with the other node. |
| JsonObject Merge(this JsonObject @this, JsonObject other) | Combines the contents of the this object with the other object. |
| JsonArray Merge(this JsonArray @this, JsonArray other) | Combines the contents of the this array with the other array. |
| JsonNode? Merge(this JsonNode @this, JsonNode? other, JsonMergeOptions options) | Combines the contents of the this node with the other node with custom merging options. |
| JsonObject Merge(this JsonObject @this, JsonObject other, JsonMergeOptions options) | Combines the contents of the this object with the other object with custom merging options. |
| JsonArray Merge(this JsonArray @this, JsonArray other, JsonMergeOptions options) | Combines the contents of the this array with the other array with custom merging options. |

## Merging Options

### Array Merge Handling

| Handling | Description | 
| --- | --- |
| Concat | Appends the nodes. |
| Union | Skips nodes that already exist. |
| Replace | Replaces the nodes. |
| Merge | Replaces the nodes within the same index. |

### Null Merge Handling 
| Handling | Description |
| --- | --- |
| Ignore | Null values are ignored during merging. |
| Merge | Null values are allowed to be merged. |