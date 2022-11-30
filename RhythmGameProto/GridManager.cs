using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RhythmGameProto
{
    public class GridManager : GameComponent
    {
        //public Dictionary<Vector2, MonogameTile> Grid;
        public MonogameTile[,] Grid;
        public int gridHeight;
        public int gridWidth;
        public Rectangle TileSize;
        private string testTile1;
        private string testTile2;
        int buffer;
        Random random = new Random();
        public GridManager(Game game) : base(game)
        {
            testTile1 = "TileTest1";
            testTile2 = "TileTest2";
            TileSize = new Rectangle(0, 0, 32, 32);
            gridHeight = 10;
            gridWidth = 15;
            //make it centered by using Game.GraphicsDevice.Viewport
            buffer = 100;
            Grid = createGrid();
        }

        private string getTileTexture()
        {
            return "";
        }
        private MonogameTile[,] createGrid()
        {
            MonogameTile t;
            Vector2 pos;
            MonogameTile[,] grid = new MonogameTile[gridWidth,gridHeight];
            for (int x = 0; x < gridWidth; x++)
            {
                for(int y = 0; y < gridHeight; y++)
                {
                    int num = random.Next(0, 12);
                    pos = new Vector2(x*TileSize.Width + buffer, y*TileSize.Height + buffer);
                    switch (num)
                    {
                        default:
                            t = new MonogameTile(Game, testTile1, true, new Tile(pos));
                            break;
                        case 6:
                            t = new MonogameTile(Game, testTile2, false, new Tile(pos));
                            break;
                    }
                    t.Position = pos;
                    grid[x,y] = t;
                }
            }
            return grid;
        }
        
        public bool isWalkable(Vector2 gridPos)
        {
            if (Grid[(int)gridPos.X, (int)gridPos.Y].IsWalkable)
            {
                return true;
            }
            return false;
        }
        
    }
}
