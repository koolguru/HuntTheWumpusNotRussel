using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HuntTheWumpusXNAGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class NodeTest
    {
        public bool[] Connections;
        public Vector2 pos;
        public Hexagon hex;
        public Node node;
        public NodeTest(Node node, Vector2 pos)
        {
            this.node = node;
            this.pos = pos;
            this.hex = new Hexagon(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y), 200, 200, this);
            Connections = new bool[] { false, false, false, false, false, false };
        }
        public void Update()
        {
            this.hex = new Hexagon(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y), 200, 200, this);
            //if (this.pos.X > .9 * Game1.graphics.GraphicsDevice.Viewport.Width)
            //{
            //    pos.X = Convert.ToInt32(.1 * Game1.graphics.GraphicsDevice.Viewport.Width) + 1;
            //}
            //else if (pos.X < .1 * Game1.graphics.GraphicsDevice.Viewport.Width)
            //{
            //    pos.X = Convert.ToInt32(.9 * Game1.graphics.GraphicsDevice.Viewport.Width) - 1;
            //}
        }
    }
    public class PlayerTest
    {
        public NodeTest room;
        public Rectangle bounding;
        public NodeTest targetRoom;
        public List<Item> items;
        public List<NodeTest> visitedRooms;
        public Player player;
        public PlayerTest(NodeTest room, Rectangle bounding, Player player)
        {
            this.room = room;
            this.bounding = bounding;
            items = new List<Item>();
            visitedRooms = new List<NodeTest>();
            this.player = player;
        }
        public void Update(List<NodeTest> nodes)
        {
            foreach (NodeTest node in Game1.nodes)
            {
                NodeTest temp = room;
                if (node != temp)
                {
                    node.hex.checkArea(new Point(375, 125), this);
                }
                foreach (Node n in node.node.connections)
                {
                    if (Engine.valueList[node.node.nodeNumber - 1][0] == n.nodeNumber)
                    {
                        node.Connections[0] = true;
                    }
                    if (Engine.valueList[node.node.nodeNumber - 1][1] == n.nodeNumber)
                    {
                        node.Connections[1] = true;
                    }
                    if (Engine.valueList[node.node.nodeNumber - 1][2] == n.nodeNumber)
                    {
                        node.Connections[2] = true;
                    }
                    if (Engine.valueList[node.node.nodeNumber - 1][3] == n.nodeNumber)
                    {
                        node.Connections[3] = true;
                    }
                    if (Engine.valueList[node.node.nodeNumber - 1][4] == n.nodeNumber)
                    {
                        node.Connections[4] = true;
                    }
                    if (Engine.valueList[node.node.nodeNumber - 1][5] == n.nodeNumber)
                    {
                        node.Connections[5] = true;
                    }
                }
                //if (Math.Abs(node.pos.X - room.pos.X) < 5 && Math.Abs(node.pos.Y - room.pos.Y - 200) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[0] = true;
                //    }
                //    else
                //    {
                //        room.Connections[0] = false;
                //    }
                //}
                //else if (Math.Abs(node.pos.X - room.pos.X - 150) < 5 && Math.Abs(node.pos.Y - room.pos.Y - 100) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[1] = true;
                //    }
                //    else
                //    {
                //        room.Connections[1] = false;
                //    }
                //}
                //else if (Math.Abs(node.pos.X - room.pos.X - 150) < 5 && Math.Abs(node.pos.Y - room.pos.Y + 100) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[2] = true;
                //    }
                //    else
                //    {
                //        room.Connections[2] = false;
                //    }
                //}
                //else if (Math.Abs(node.pos.X - room.pos.X) < 5 && Math.Abs(node.pos.Y - room.pos.Y + 200) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[3] = true;
                //    }
                //    else
                //    {
                //        room.Connections[3] = false;
                //    }
                //}
                //else if (Math.Abs(node.pos.X - room.pos.X + 150) < 5 && Math.Abs(node.pos.Y - room.pos.Y + 100) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[4] = true;
                //    }
                //    else
                //    {
                //        room.Connections[4] = false;
                //    }
                //}
                //else if (Math.Abs(node.pos.X - room.pos.X + 150) < 5 && Math.Abs(node.pos.Y - room.pos.Y - 100) < 5)
                //{
                //    if (room.node.connections.Contains(node.node))
                //    {
                //        room.Connections[5] = true;
                //    }
                //    else
                //    {
                //        room.Connections[5] = false;
                //    }
                //}
            }
            room.Update();
            }
    }
    public class Button
    {
        public int x;
        public int y;
        public int width;
        public int height;  
        public Rectangle bounding;
        public Button(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.bounding = new Rectangle(x, y, width, height); 
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D caveTex;
        public static PlayerTest player;
        bool[] doors;
        Texture2D edge;
        public static List<NodeTest> nodes;
        Texture2D playerTex;
        public static Texture2D twelve;
        public static Texture2D two;
        public static Texture2D four;
        public static Texture2D six;
        public static Texture2D eight;
        public static Texture2D ten;
        Texture2D lineTest;
        Trivia trivia;
        TriviaQuestion tQuestion;
        TriviaAnswer tAnswerA;
        TriviaAnswer tAnswerB;
        TriviaAnswer tAnswerC;
        TriviaAnswer tAnswerD;
        Question question;
        enum GameState { Menu, MainGame, GameOver };
        SpriteFont spriteFont;
        KeyboardState oldState;
        MouseState oldMouse;
        int score;
        Texture2D dummyTexture;
        int currentTurn = 0;
        SpriteFont UIFont;
        Texture2D menuTex;
        GameState gamestate;
        Engine engine;
        List<Node> engineNodes;
        Button startGame;
        bool debug;
        Vector2 newPos;
        Vector2 speed;
        public static HighScore highScore;
        Texture2D caveCover;
        Texture2D inventoryBackground;
        Texture2D soup;
        Player play;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Resize the screen.
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            //Make game FullScreen
            //graphics.ToggleFullScreen();
        }
        public static void Exit()
        {
            Game1.Exit();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void createMap()
        {
            engine = new Engine();
            engineNodes = engine.genMap();
            nodes = new List<NodeTest>();
            for (int i = 0; i < 30; i++)
            {
                int x = (i % 6) * 150 - 50;
                int y = (i / 6) * 200 + 50;
                if (i % 2 == 1)
                {
                    y += 100;
                }
                nodes.Add(new NodeTest(engineNodes[i], new Vector2(x, y)));
            }
            foreach (NodeTest nt in nodes)
            {
                nt.node.room = nt;
            }
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Define all variables not defined in Initizalize
            doors = new bool[] { true, false, true, true, false, false };
            gamestate = GameState.Menu;
            menuTex = Content.Load<Texture2D>("MenuScreen1");
            createMap();
            startGame = new Button(530, 480, 405, 150);
            playerTex = Content.Load<Texture2D>("Player");
            player = new PlayerTest(nodes[0], new Rectangle((graphics.GraphicsDevice.Viewport.Width / 2) - (playerTex.Width / 2), 100, 50, 50), play);
            play = new Player(player, 3, 0);
            twelve = Content.Load<Texture2D>("0");
            two = Content.Load<Texture2D>("1");
            four = Content.Load<Texture2D>("2");
            six = Content.Load<Texture2D>("3");
            eight = Content.Load<Texture2D>("4");
            ten = Content.Load<Texture2D>("5");
            lineTest = Content.Load<Texture2D>("LineTest");
            //Load Content
            caveTex = Content.Load<Texture2D>("Cave");
            edge = Content.Load<Texture2D>("ViewportEdge");
            inventoryBackground = Content.Load<Texture2D>("InventoryBackground");
            trivia = new Trivia();
            tQuestion = new TriviaQuestion("", 0);
            tAnswerA = new TriviaAnswer("", 1);
            tAnswerB = new TriviaAnswer("", 2);
            tAnswerC = new TriviaAnswer("", 3);
            tAnswerD = new TriviaAnswer("", 4);
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            UIFont = Content.Load<SpriteFont>("UIFont");
            oldState = Keyboard.GetState();
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1); //Creates a dummy texture to make solid black rectangles
            dummyTexture.SetData(new Color[] { Color.Black });
            caveCover = Content.Load<Texture2D>("Cover");
            gamestate = GameState.Menu; //Starts game on menu
            newPos = new Vector2(player.bounding.Center.X, player.bounding.Center.Y );
            player.targetRoom = nodes[4];
            highScore = new HighScore(0, 0, 0);
            soup = Content.Load<Texture2D>("soup");
            player.items.Add(new Item("Bowl of Soup", "Warm and thick, just like mom used to make...", soup, new Rectangle(700, 600, 100, 150), 0));
            double hypotinuse = Math.Sqrt(Math.Pow((player.bounding.Center.X - newPos.X), 2) + Math.Pow((player.bounding.Center.Y - newPos.Y + 16), 2));
            newPos = new Vector2(player.targetRoom.pos.X + 100, player.targetRoom.pos.Y + 100);
            speed = new Vector2(Convert.ToSingle((player.bounding.Center.X - newPos.X) / hypotinuse), Convert.ToSingle((player.bounding.Center.Y - newPos.Y) / hypotinuse));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            player.room.hex.Update();
            // TODO: Add your update logic here
            ///////////////////
            // Menu Controls //
            ///////////////////
            if (gamestate == GameState.Menu)
            {
                if (startGame.bounding.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    menuTex = Content.Load<Texture2D>("MenuScreen2");
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        gamestate = GameState.MainGame;
                }
                else
                    menuTex = Content.Load<Texture2D>("MenuScreen1");
            }
            ///////////////////
            // Game Controls //
            ///////////////////
            if (gamestate == GameState.MainGame)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R) && !oldState.IsKeyDown(Keys.R))
                {
                    double hypotinuse = Math.Sqrt(Math.Pow((player.bounding.Center.X - newPos.X), 2) + Math.Pow((player.bounding.Center.Y - newPos.Y + 16), 2));
                    newPos = new Vector2(player.targetRoom.pos.X + 100, player.targetRoom.pos.Y + 100);
                    speed = new Vector2(Convert.ToSingle((player.bounding.Center.X - newPos.X) / hypotinuse), Convert.ToSingle((player.bounding.Center.Y - newPos.Y) / hypotinuse));
                    engineNodes.Clear();
                    nodes.Clear();
                    createMap();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.T) && !oldState.IsKeyDown(Keys.T))
                {
                    UpdateTrivia();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
                {
                    debug = !debug;
                }
                player.Update(nodes);
                    if (new Rectangle(player.bounding.X + 25, player.bounding.Y + 25, 1, 1).Intersects(new Rectangle(Convert.ToInt32(player.targetRoom.pos.X + 100), Convert.ToInt32(player.targetRoom.pos.Y + 100), 1, 10)))
                    {
                        speed = new Vector2(0, 0);
                        if (!player.visitedRooms.Contains(player.targetRoom))
                        {
                            player.visitedRooms.Add(player.targetRoom);
                            Player.Gold++;
                        }
                    }
                    foreach (NodeTest n in nodes)
                    {
                        if (n.pos.Y > 800)
                        {
                            n.pos.Y -= 1000;
                        }
                        else if (n.pos.Y < -200)
                        {
                            n.pos.Y += 1000;
                        }
                        if (n.pos.X > 900)
                        {
                            n.pos.X -= 900;
                        }
                        else if (n.pos.X < 0)
                        {
                            n.pos.X += 900;
                        }
                        n.pos += speed;
                    }
                    if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed) && oldMouse.LeftButton.Equals(ButtonState.Released))
                    {
                        foreach (NodeTest n in nodes)
                        {
                            if (new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                            {
                                if (player.room.node.connections.Contains(n.node) && speed == new Vector2(0, 0))
                                {   
                                    player.targetRoom = n;
                                    Game1.highScore.NumberOfTurns++;
                                    double hypotinuse = Math.Sqrt(Math.Pow((player.bounding.Center.X - newPos.X), 2) + Math.Pow((player.bounding.Center.Y - newPos.Y + 16), 2));
                                    newPos = new Vector2(player.targetRoom.pos.X + 100, player.targetRoom.pos.Y + 100);
                                    speed = new Vector2(Convert.ToSingle((player.bounding.Center.X - newPos.X) / hypotinuse), Convert.ToSingle((player.bounding.Center.Y - newPos.Y) / hypotinuse));
                                }
                            }
                        }
                        if (new Rectangle(20, Convert.ToInt32(tAnswerA.bounding.Y), Convert.ToInt32(spriteFont.MeasureString(tAnswerA.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                        {
                            if (question.answer == 1)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                            ClearTrivia();
                        }
                        else if (new Rectangle(20, Convert.ToInt32(tAnswerB.bounding.Y), Convert.ToInt32(spriteFont.MeasureString(tAnswerB.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                        {
                            if (question.answer == 2)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                            ClearTrivia();
                        }
                        else if (new Rectangle(20, Convert.ToInt32(tAnswerC.bounding.Y), Convert.ToInt32(spriteFont.MeasureString(tAnswerC.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                        {
                            if (question.answer == 3)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                            ClearTrivia();
                        }
                        else if (new Rectangle(20, Convert.ToInt32(tAnswerD.bounding.Y), Convert.ToInt32(spriteFont.MeasureString(tAnswerD.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                        {
                            if (question.answer == 4)
                            {
                                score++;
                            }
                            else
                            {
                                score--;
                            }
                            ClearTrivia();
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.L))
                    {
                        ClearTrivia();
                    }
                }
            play.Update(player);
            oldMouse = Mouse.GetState();
            oldState = Keyboard.GetState();
            base.Update(gameTime);
            }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void UpdateTrivia()
        {
            question = trivia.FetchQuestion();
            tQuestion.question = question.questionText;
            tQuestion.correctAnswer = question.answer;
            tAnswerA.question = question.choice1;
            tAnswerB.question = question.choice2;
            tAnswerC.question = question.choice3;
            tAnswerD.question = question.choice4;
        }
        public void ClearTrivia()
        {
            tQuestion.question = "";
            tQuestion.correctAnswer = 0;
            tAnswerA.question = "";
            tAnswerB.question = "";
            tAnswerC.question = "";
            tAnswerD.question = "";
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (gamestate == GameState.Menu) //When game is on Menu
                spriteBatch.Draw(menuTex, new Rectangle(0, 0,graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White); //Draws Menu Background
            if (gamestate == GameState.MainGame)
            {
                //UI Draw Functions
                spriteBatch.Draw(dummyTexture, new Rectangle(0, 972, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 972), Color.Black); //Draws the Bottom Black UI Backing
                spriteBatch.DrawString(UIFont, "Turn: " + currentTurn, new Vector2(1750, 1000), Color.White); //Draws the Turn Number   
                spriteBatch.DrawString(UIFont, Convert.ToString(gameTime.TotalGameTime).Substring(3, 5), new Vector2(31, 1000), Color.White); //Draws the game timer

                foreach (NodeTest n in nodes)
                {
                    spriteBatch.Draw(caveTex, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                    if (!player.visitedRooms.Contains(n))
                    {
                        spriteBatch.Draw(caveCover, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                    }
                    if (player.visitedRooms.Contains(n))
                    {
                        if (n.Connections[0])
                        {
                            spriteBatch.Draw(twelve, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                        if (n.Connections[1])
                        {
                            spriteBatch.Draw(two, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                        if (n.Connections[2])
                        {
                            spriteBatch.Draw(four, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                        if (n.Connections[3])
                        {
                            spriteBatch.Draw(six, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                        if (n.Connections[4])
                        {
                            spriteBatch.Draw(eight, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                        if (n.Connections[5])
                        {
                            spriteBatch.Draw(ten, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                        }
                    }
                }
                spriteBatch.Draw(inventoryBackground, new Rectangle(0, Convert.ToInt32(graphics.GraphicsDevice.Viewport.Height * .597), graphics.GraphicsDevice.Viewport.Width, Convert.ToInt32(graphics.GraphicsDevice.Viewport.Height * .402)), Color.White);
                for (int i = 0; i < player.items.Count; i++)
                {
                    spriteBatch.Draw(player.items[i].texture, new Rectangle(Convert.ToInt32(graphics.GraphicsDevice.Viewport.Width * .55) + (i * 200), Convert.ToInt32(graphics.GraphicsDevice.Viewport.Height * .7), 100, 150), Color.White);
                }
                spriteBatch.Draw(edge, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(playerTex, player.bounding, Color.White);
                spriteBatch.DrawString(spriteFont, tQuestion.question, new Vector2(20, graphics.GraphicsDevice.Viewport.Height - 96), Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerA.question, tAnswerA.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerB.question, tAnswerB.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerC.question, tAnswerC.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerD.question, tAnswerD.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, "Turns: " + highScore.NumberOfTurns, new Vector2(20, 20), Color.Gold);
                spriteBatch.DrawString(spriteFont, "Gold: " + Player.Gold, new Vector2(20, 40), Color.Gold);
                spriteBatch.DrawString(spriteFont, "Arrows: " + Player.Arrows, new Vector2(20, 60), Color.Gold);
                if (debug)
                {
                    foreach (Vector2 v in player.room.hex.twelve.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.two.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.four.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.six.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.eight.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.ten.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (NodeTest n in nodes)
                    {
                        if (new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                        {
                            spriteBatch.DrawString(spriteFont, n.pos.X + " " + n.pos.Y, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                        }
                    }
                }
            }
            if (debug)
            {
                foreach (NodeTest n in nodes)
                {
                    spriteBatch.DrawString(spriteFont, Convert.ToString(n.node.nodeNumber), new Vector2(n.pos.X + 100, n.pos.Y + 100), Color.Gold);
                }
                spriteBatch.DrawString(spriteFont, player.room.node.connections[0].nodeNumber + ", " + player.room.node.connections[1].nodeNumber + ", " + player.room.node.connections[2].nodeNumber, new Vector2(player.room.pos.X + 30, player.room.pos.Y), Color.Gold);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

