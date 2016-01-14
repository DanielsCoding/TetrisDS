using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace TetrisVersuch2
{

    public static class GameHelper
    {
        private static Random randomZahl = new Random();

        public static Direction GetNextDirection(Direction direction)
        {

            if (direction == Direction.Up)
            {
                return Direction.Right;
            }
            if (direction == Direction.Right)
            {
                return Direction.Down;
            }
            if (direction == Direction.Down)
            {
                return Direction.Left;
            }
            if (direction == Direction.Left)
            {
                return Direction.Up;
            }

            return Direction.Up;
        }


        //Methode GetBlock By BlockType & Direction
        public static BlockItem GetBlockByTypeAndDirection(BlockType blocktype, Direction direction)
        {
            #region GetNewDirectionLBlockRight
            if (blocktype == BlockType.LBlockRight && direction == Direction.Right)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                 {
                     Color = Color.Blue,
                     X = 0,
                     Y = 0,
                     MainItem = true,

                 });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 2,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.LBlockRight && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = -2,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.LBlockRight && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = -2,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.LBlockRight && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Blue,
                    X = 2,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            #endregion

            #region GetNewDirectionIBlock
            if (blocktype == BlockType.IBlock && direction == Direction.Right)
            {
                //hier jetzt die werte des hellblauen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                 {
                     Color = Color.SkyBlue,
                     X = 0,
                     Y = 0,
                     MainItem = true,

                 });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 2,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.IBlock && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 2,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.IBlock && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = -2,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.IBlock && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = -2,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.SkyBlue,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            #endregion

            #region GetNewDirectionLBlockLeft
            if (blocktype == BlockType.LBlockLeft && direction == Direction.Right)
            {
                //hier jetzt die werte des orangenen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                 {
                     Color = Color.Orange,
                     X = 0,
                     Y = 0,
                     MainItem = true,

                 });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = -2,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.LBlockLeft && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 2,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.LBlockLeft && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 2,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.LBlockLeft && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Orange,
                    X = -2,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            #endregion

            #region GetNewDirectionSBlockRight
            if (blocktype == BlockType.SBlockRight && direction == Direction.Right)
            {
                //hier jetzt die werte des grünen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 1,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.SBlockRight && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = -1,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.SBlockRight && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = -1,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.SBlockRight && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Green,
                    X = 1,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }
            #endregion

            #region GetNewDirectionPyramidBlock
            if (blocktype == BlockType.PyramidBlock && direction == Direction.Right)
            {
                //hier jetzt die werte des lilanen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.PyramidBlock && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.PyramidBlock && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.PyramidBlock && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Purple,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                return myblockItem;
            }
            #endregion

            #region GetNewDirectionSBlockLeft
            if (blocktype == BlockType.SBlockLeft && direction == Direction.Right)
            {
                //hier jetzt die werte des lilanen blockes neu festlegen wenn er dann einmal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 1,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.SBlockLeft && direction == Direction.Down)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann zweimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };
                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 1,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }
            else if (blocktype == BlockType.SBlockLeft && direction == Direction.Left)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann dreimal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 0,
                    MainItem = true,

                });
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = -1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = -1,
                    Y = 1,
                    MainItem = false
                });

                return myblockItem;
            }

            else if (blocktype == BlockType.SBlockLeft && direction == Direction.Up)
            {
                //hier jetzt die werte des blauen blockes neu festlegen wenn er dann viermal um 90° gedreht wurde also nach rechts zeigt
                var myblockItem = new BlockItem()
                {
                    BlockType = blocktype,
                    Direction = direction
                };

                myblockItem.BlockList = new List<Block>();

                //werte:
                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = 0,
                    MainItem = true
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 1,
                    Y = 0,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = 0,
                    Y = -1,
                    MainItem = false
                });

                myblockItem.BlockList.Add(new Block()
                {
                    Color = Color.Red,
                    X = -1,
                    Y = -1,
                    MainItem = false
                });

                return myblockItem;
            }
            return null;

            #endregion
        }

        public static BlockItem GetBlockItem()
        {
            var myblockItem = new BlockItem()
            {
                X = 7,
                Y = 0,      //start position
                Direction = Direction.Up
            };
            myblockItem.BlockList = new List<Block>();

            //todo: ds direkteingabe            
            var zufallsZahl = randomZahl.Next(1, 8);  //auswählen des Blockes von dem Computer und erstellen der Blöcke
            //var zufallsZahl = 2;

            switch (zufallsZahl)
            {
                case 1:
                    #region Block Blue

                    myblockItem.BlockType = BlockType.LBlockRight;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Blue,
                        X = 0,
                        Y = 0,
                        MainItem = true,

                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Blue,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Blue,
                        X = 1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Blue,
                        X = 2,
                        Y = 0,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 2:
                    #region Block SkyBlue

                    myblockItem.BlockType = BlockType.IBlock;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.SkyBlue,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.SkyBlue,
                        X = -1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.SkyBlue,
                        X = 1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.SkyBlue,
                        X = 2,
                        Y = 0,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 3:
                    #region Block Orange

                    myblockItem.BlockType = BlockType.LBlockLeft;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Orange,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Orange,
                        X = -1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Orange,
                        X = -2,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Orange,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 4:
                    #region Block Yellow

                    myblockItem.BlockType = BlockType.DiceBlock;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Yellow,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Yellow,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Yellow,
                        X = 1,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Yellow,
                        X = 1,
                        Y = 0,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 5:
                    #region Block Green

                    myblockItem.BlockType = BlockType.SBlockRight;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Green,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Green,
                        X = -1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Green,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Green,
                        X = 1,
                        Y = -1,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 6:
                    #region Block Purple

                    myblockItem.BlockType = BlockType.PyramidBlock;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Purple,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Purple,
                        X = -1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Purple,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Purple,
                        X = 1,
                        Y = 0,
                        MainItem = false
                    });

                    #endregion
                    break;
                case 7:
                    #region Block Red

                    myblockItem.BlockType = BlockType.SBlockLeft;

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Red,
                        X = 0,
                        Y = 0,
                        MainItem = true
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Red,
                        X = 1,
                        Y = 0,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Red,
                        X = 0,
                        Y = -1,
                        MainItem = false
                    });

                    myblockItem.BlockList.Add(new Block()
                    {
                        Color = Color.Red,
                        X = -1,
                        Y = -1,
                        MainItem = false
                    });

                    #endregion
                    break;
                default:
                    Console.WriteLine("Ungültiger Block entdeckt");
                    break;
            }

            return myblockItem;
        }
    }

    public class Block
    {
        public Color Color { get; set; }

        public bool MainItem { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public class BlockItem
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction Direction { get; set; }
        public BlockType BlockType { get; set; }

        public List<Block> BlockList { get; set; }
    }

    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public enum BlockType
    {
        IBlock,
        LBlockRight,
        LBlockLeft,
        DiceBlock,
        SBlockRight,
        PyramidBlock,
        SBlockLeft
    }
}
