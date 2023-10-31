# Elements.Triangulation

This library is currently a very thin wrapper around the [VoronatorSharp](https://github.com/BorisTheBrave/voronator-sharp) project. 

It exposes a single method, `Elements.Triangulation.Trinagulation.ComputeVoronoiPolygons`, which computes the voronoi diagram of the provided points.

## Method Signature
```csharp
public static List<Profile> ComputeVoronoiPolygons(IList<Vector3> points, Profile? trimBoundary = null)
```

### Parameters
- `points`: List of `Vector3` points to be triangulated.
- `trimBoundary`: Optional `Profile` object to trim the Voronoi polygons.

### Returns
- `List<Profile>`: A list of `Profile` objects representing Voronoi polygons.


# Building the project

This project assumes you have cloned `voronator-sharp` and put it adjacent to this project. After that, `dotnet build` should suffice.