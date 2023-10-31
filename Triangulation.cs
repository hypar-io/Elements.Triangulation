namespace Elements.Triangulation;
using Elements.Geometry;
using VoronatorSharp;
public class Triangulation
{
    public static List<Profile> ComputeVoronoiPolygons(IList<Vector3> points, Profile? trimBoundary = null)
    {

        var polygons = new List<Polygon>();
        var points2d = points.Select((p) => p.ToVector2()).ToArray();
        var boundingBox = new BBox3(points);
        // double the bounding box to ensure that the voronoi diagram
        // covers the entire area of the points.
        var center = boundingBox.Center();
        boundingBox.Min += (boundingBox.Min - center);
        boundingBox.Max += (boundingBox.Max - center);
        var v = new Voronator(points2d, boundingBox.Min.ToVector2(), boundingBox.Max.ToVector2());
        var trimBoundaryList = trimBoundary == null ? new List<Profile>() : new List<Profile> { trimBoundary };
        return new List<Profile>(points.SelectMany((p, i) =>
        {
            var vertices = v.GetClippedPolygon(i);
            if (vertices is null)
            {
                return Enumerable.Empty<Profile>();
            }
            try
            {
                var polygon = vertices.ToPolygon();
                var polygonList = new List<Profile> { polygon };
                if (trimBoundary != null)
                {
                    var profiles = Profile.Intersection(polygonList, trimBoundaryList);
                    return profiles;
                }
                return polygonList;
            }
            catch
            {
                return Enumerable.Empty<Profile>();
            }
        }));
    }
}
