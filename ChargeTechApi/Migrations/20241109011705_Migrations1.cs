using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChargeTechApi.Migrations
{
    /// <inheritdoc />
    public partial class Migrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CT_AMBIENTE",
                columns: table => new
                {
                    ID_AMBIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_AMBIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_AMBIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_AMBIENTE", x => x.ID_AMBIENTE);
                });

            migrationBuilder.CreateTable(
                name: "CT_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_NASCIMENTO_USUARIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SENHA_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "CT_DISPOSITIVO",
                columns: table => new
                {
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_DISPOSITIVO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IMAGEM_DISPOSITIVO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CONSUMO_MEDIO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_AMBIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_DISPOSITIVO", x => x.ID_DISPOSITIVO);
                    table.ForeignKey(
                        name: "FK_CT_DISPOSITIVO_CT_AMBIENTE_ID_AMBIENTE",
                        column: x => x.ID_AMBIENTE,
                        principalTable: "CT_AMBIENTE",
                        principalColumn: "ID_AMBIENTE",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CT_DISPOSITIVO_CT_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "CT_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CT_CONSUMO_ENERGETICO",
                columns: table => new
                {
                    ID_CONSUMO_ENERGETICO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CONSUMO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CUSTO_ESTIMADO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CUSTO_CONSUMO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_CONSUMO_ENERGETICO", x => x.ID_CONSUMO_ENERGETICO);
                    table.ForeignKey(
                        name: "FK_CT_CONSUMO_ENERGETICO_CT_DISPOSITIVO_ID_DISPOSITIVO",
                        column: x => x.ID_DISPOSITIVO,
                        principalTable: "CT_DISPOSITIVO",
                        principalColumn: "ID_DISPOSITIVO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_CONSUMO_ENERGETICO_ID_DISPOSITIVO",
                table: "CT_CONSUMO_ENERGETICO",
                column: "ID_DISPOSITIVO");

            migrationBuilder.CreateIndex(
                name: "IX_CT_DISPOSITIVO_ID_AMBIENTE",
                table: "CT_DISPOSITIVO",
                column: "ID_AMBIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_CT_DISPOSITIVO_ID_USUARIO",
                table: "CT_DISPOSITIVO",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_CONSUMO_ENERGETICO");

            migrationBuilder.DropTable(
                name: "CT_DISPOSITIVO");

            migrationBuilder.DropTable(
                name: "CT_AMBIENTE");

            migrationBuilder.DropTable(
                name: "CT_USUARIO");
        }
    }
}
