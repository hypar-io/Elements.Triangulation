using Elements.Geometry;
using VoronatorSharp;

namespace Elements.Triangulation
{
    public static class Conversion
    {
        public static Vector2 ToVector2(this Vector3 v) => new Vector2((float)v.X, (float)v.Y);

        public static Vector3 ToVector3(this Vector2 v) => new Vector3(v.x, v.y);
        public static Polygon ToPolygon(this IEnumerable<Vector2> vertices) => new Polygon(vertices.Select(v => v.ToVector3()).ToList());
    }
}