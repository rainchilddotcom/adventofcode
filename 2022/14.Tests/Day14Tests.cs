namespace _14.Tests
{
    public class Day14Tests
    {
        const string testInput =
@"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void LoadLevel()
        {
            var level = new CaveLoader()
                .LoadCave(input);

            level.RenderMap()
                 .Should().Be(
@"      +   
          
          
          
    #   ##
    #   # 
  ###   # 
        # 
        # 
######### 
");
        }

        [Test]
        public void SpawnSand()
        {
            var level = new CaveLoader()
                .LoadCave(input);

            var sand = level.SpawnSand();
            sand.Count.Should().Be(1);

            level.SettleSand(sand)
                .Should().Be(8);

            for (int i = 1; i < 8; i++)
            {
                level[500, i].Z
                    .Should().Be(" ");
            }

            level[500, 8].Z
                .Should().Be("o");
        }

        [Test]
        public void SpawnMultiple()
        {
            var level = new CaveLoader()
                .LoadCave(input);

            {
                var sand = level.SpawnSand();
                sand.Count.Should().Be(1);

                level.SettleSand(sand)
                    .Should().Be(8);

                level[500, 8].Z
                    .Should().Be("o");
            }

            {
                var sand = level.SpawnSand();
                sand.Count.Should().Be(1);

                level.SettleSand(sand)
                    .Should().Be(8);

                level[499, 8].Z
                    .Should().Be("o");
            }

            {
                var sand = level.SpawnSand();
                sand.Count.Should().Be(1);

                level.SettleSand(sand)
                    .Should().Be(8);

                level[501, 8].Z
                    .Should().Be("o");
            }

            {
                var sand = level.SpawnSand();
                sand.Count.Should().Be(1);

                level.SettleSand(sand)
                    .Should().Be(7);

                level[500, 7].Z
                    .Should().Be("o");
            }

            {
                var sand = level.SpawnSand();
                sand.Count.Should().Be(1);

                level.SettleSand(sand)
                    .Should().Be(8);

                level[498, 8].Z
                    .Should().Be("o");
            }

            level.RenderMap()
                .Should().Be(
@"      +   
          
          
          
    #   ##
    #   # 
  ###   # 
      o # 
    oooo# 
######### 
");
        }

        [Test]
        public void SpawnIntoAbyss()
        {
            var level = new CaveLoader()
                .LoadCave(input);

            level.FillCavern();

            level.TotalSand
                .Should().Be(24);

            level.RenderMap()
                .Should().Be(
@"       +   
       ~   
      ~o   
     ~ooo  
    ~#ooo##
   ~o#ooo# 
  ~###ooo# 
  ~  oooo# 
 ~o ooooo# 
~######### 
~          
~          
~          
           
");
        }

        [Test]
        public void FillCave()
        {
            var level = new CaveLoader()
                .LoadCave(input);

            level.AddFloor();
            level.FillCavern();

            level.TotalSand
                .Should().Be(93);

            level.RenderMap()
                .Should().Be(
@"            o            
           ooo           
          ooooo          
         ooooooo         
        oo#ooo##o        
       ooo#ooo#ooo       
      oo###ooo#oooo      
     oooo oooo#ooooo     
    oooooooooo#oooooo    
   ooo#########ooooooo   
  ooooo       ooooooooo  
#########################
");
        }
    }
}