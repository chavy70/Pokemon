using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemon.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id_Species = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id_Species);
                });

            migrationBuilder.CreateTable(
                name: "Sprites",
                columns: table => new
                {
                    Id_Sprites = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Front_Default = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Front_Shiny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Front_Female = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Front_Shiny_Female = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Back_Default = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Back_Shiny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Back_Female = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Back_Shiny_Female = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprites", x => x.Id_Sprites);
                });

            migrationBuilder.CreateTable(
                name: "VersionInfo",
                columns: table => new
                {
                    Id_VersionInfo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionInfo", x => x.Id_VersionInfo);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id_Pokemons = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Base_Experience = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Is_Default = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    SpritesId_Sprites = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpeciesId_Species = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id_Pokemons);
                    table.ForeignKey(
                        name: "FK_Pokemons_Species_SpeciesId_Species",
                        column: x => x.SpeciesId_Species,
                        principalTable: "Species",
                        principalColumn: "Id_Species",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemons_Sprites_SpritesId_Sprites",
                        column: x => x.SpritesId_Sprites,
                        principalTable: "Sprites",
                        principalColumn: "Id_Sprites",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityInfo",
                columns: table => new
                {
                    Id_AbilityInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Hidden = table.Column<bool>(type: "bit", nullable: true),
                    Slot = table.Column<int>(type: "int", nullable: true),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityInfo", x => x.Id_AbilityInfo);
                    table.ForeignKey(
                        name: "FK_AbilityInfo_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id_Form = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id_Form);
                    table.ForeignKey(
                        name: "FK_Form_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                });

            migrationBuilder.CreateTable(
                name: "GameIndex",
                columns: table => new
                {
                    Id_GameIndex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Game_Index = table.Column<int>(type: "int", nullable: true),
                    VersionId_VersionInfo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameIndex", x => x.Id_GameIndex);
                    table.ForeignKey(
                        name: "FK_GameIndex_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                    table.ForeignKey(
                        name: "FK_GameIndex_VersionInfo_VersionId_VersionInfo",
                        column: x => x.VersionId_VersionInfo,
                        principalTable: "VersionInfo",
                        principalColumn: "Id_VersionInfo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoveInfo",
                columns: table => new
                {
                    Id_MoveInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveInfo", x => x.Id_MoveInfo);
                    table.ForeignKey(
                        name: "FK_MoveInfo_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                });

            migrationBuilder.CreateTable(
                name: "StatInfo",
                columns: table => new
                {
                    Id_StatInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base_Stat = table.Column<int>(type: "int", nullable: true),
                    Effort = table.Column<int>(type: "int", nullable: true),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatInfo", x => x.Id_StatInfo);
                    table.ForeignKey(
                        name: "FK_StatInfo_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                });

            migrationBuilder.CreateTable(
                name: "TypeInfo",
                columns: table => new
                {
                    Id_TypeInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot = table.Column<int>(type: "int", nullable: true),
                    Id_Pokemons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInfo", x => x.Id_TypeInfo);
                    table.ForeignKey(
                        name: "FK_TypeInfo_Pokemons_Id_Pokemons",
                        column: x => x.Id_Pokemons,
                        principalTable: "Pokemons",
                        principalColumn: "Id_Pokemons");
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id_Ability = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_AbilityInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id_Ability);
                    table.ForeignKey(
                        name: "FK_Ability_AbilityInfo_Id_AbilityInfo",
                        column: x => x.Id_AbilityInfo,
                        principalTable: "AbilityInfo",
                        principalColumn: "Id_AbilityInfo");
                });

            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    Id_Move = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_MoveInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.Id_Move);
                    table.ForeignKey(
                        name: "FK_Move_MoveInfo_Id_MoveInfo",
                        column: x => x.Id_MoveInfo,
                        principalTable: "MoveInfo",
                        principalColumn: "Id_MoveInfo");
                });

            migrationBuilder.CreateTable(
                name: "VersionGroupDetail",
                columns: table => new
                {
                    Id_VersionGroupDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_Learned_At = table.Column<int>(type: "int", nullable: true),
                    Id_MoveInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionGroupDetail", x => x.Id_VersionGroupDetail);
                    table.ForeignKey(
                        name: "FK_VersionGroupDetail_MoveInfo_Id_MoveInfo",
                        column: x => x.Id_MoveInfo,
                        principalTable: "MoveInfo",
                        principalColumn: "Id_MoveInfo");
                });

            migrationBuilder.CreateTable(
                name: "Stat",
                columns: table => new
                {
                    Id_Stat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_StatInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stat", x => x.Id_Stat);
                    table.ForeignKey(
                        name: "FK_Stat_StatInfo_Id_StatInfo",
                        column: x => x.Id_StatInfo,
                        principalTable: "StatInfo",
                        principalColumn: "Id_StatInfo");
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id_Type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_TypeInfo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id_Type);
                    table.ForeignKey(
                        name: "FK_Type_TypeInfo_Id_TypeInfo",
                        column: x => x.Id_TypeInfo,
                        principalTable: "TypeInfo",
                        principalColumn: "Id_TypeInfo");
                });

            migrationBuilder.CreateTable(
                name: "MoveLearnMethod",
                columns: table => new
                {
                    Id_MoveLearnMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_VersionGroupDetail = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveLearnMethod", x => x.Id_MoveLearnMethod);
                    table.ForeignKey(
                        name: "FK_MoveLearnMethod_VersionGroupDetail_Id_VersionGroupDetail",
                        column: x => x.Id_VersionGroupDetail,
                        principalTable: "VersionGroupDetail",
                        principalColumn: "Id_VersionGroupDetail");
                });

            migrationBuilder.CreateTable(
                name: "VersionGroup",
                columns: table => new
                {
                    Id_VersionGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_VersionGroupDetail = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionGroup", x => x.Id_VersionGroup);
                    table.ForeignKey(
                        name: "FK_VersionGroup_VersionGroupDetail_Id_VersionGroupDetail",
                        column: x => x.Id_VersionGroupDetail,
                        principalTable: "VersionGroupDetail",
                        principalColumn: "Id_VersionGroupDetail");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Id_AbilityInfo",
                table: "Ability",
                column: "Id_AbilityInfo",
                unique: true,
                filter: "[Id_AbilityInfo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityInfo_Id_Pokemons",
                table: "AbilityInfo",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_Form_Id_Pokemons",
                table: "Form",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_GameIndex_Id_Pokemons",
                table: "GameIndex",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_GameIndex_VersionId_VersionInfo",
                table: "GameIndex",
                column: "VersionId_VersionInfo");

            migrationBuilder.CreateIndex(
                name: "IX_Move_Id_MoveInfo",
                table: "Move",
                column: "Id_MoveInfo",
                unique: true,
                filter: "[Id_MoveInfo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MoveInfo_Id_Pokemons",
                table: "MoveInfo",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_MoveLearnMethod_Id_VersionGroupDetail",
                table: "MoveLearnMethod",
                column: "Id_VersionGroupDetail",
                unique: true,
                filter: "[Id_VersionGroupDetail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_SpeciesId_Species",
                table: "Pokemons",
                column: "SpeciesId_Species");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_SpritesId_Sprites",
                table: "Pokemons",
                column: "SpritesId_Sprites");

            migrationBuilder.CreateIndex(
                name: "IX_Stat_Id_StatInfo",
                table: "Stat",
                column: "Id_StatInfo",
                unique: true,
                filter: "[Id_StatInfo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StatInfo_Id_Pokemons",
                table: "StatInfo",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Id_TypeInfo",
                table: "Type",
                column: "Id_TypeInfo",
                unique: true,
                filter: "[Id_TypeInfo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TypeInfo_Id_Pokemons",
                table: "TypeInfo",
                column: "Id_Pokemons");

            migrationBuilder.CreateIndex(
                name: "IX_VersionGroup_Id_VersionGroupDetail",
                table: "VersionGroup",
                column: "Id_VersionGroupDetail",
                unique: true,
                filter: "[Id_VersionGroupDetail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VersionGroupDetail_Id_MoveInfo",
                table: "VersionGroupDetail",
                column: "Id_MoveInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "GameIndex");

            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropTable(
                name: "MoveLearnMethod");

            migrationBuilder.DropTable(
                name: "Stat");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "VersionGroup");

            migrationBuilder.DropTable(
                name: "AbilityInfo");

            migrationBuilder.DropTable(
                name: "VersionInfo");

            migrationBuilder.DropTable(
                name: "StatInfo");

            migrationBuilder.DropTable(
                name: "TypeInfo");

            migrationBuilder.DropTable(
                name: "VersionGroupDetail");

            migrationBuilder.DropTable(
                name: "MoveInfo");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Sprites");
        }
    }
}
