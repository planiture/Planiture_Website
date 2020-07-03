using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Planiture_Website.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Info",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    MemberSince = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Gender = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CusAddress = table.Column<string>(nullable: true),
                    Residency = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Info", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Info",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Emp_FirstName = table.Column<string>(nullable: false),
                    Emp_LastName = table.Column<string>(nullable: false),
                    Emp_UserName = table.Column<string>(nullable: false),
                    Emp_Password = table.Column<string>(maxLength: 100, nullable: false),
                    Emp_Old_Password = table.Column<string>(nullable: false),
                    ReportsTo = table.Column<string>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Info", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Account_Info",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    AccountName = table.Column<string>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    AvailableBalance = table.Column<float>(nullable: false),
                    ActualBalance = table.Column<float>(nullable: false),
                    WithdrawalAmount = table.Column<float>(nullable: false),
                    DepositAmount = table.Column<float>(nullable: false),
                    OtherAccount = table.Column<string>(nullable: false),
                    Acc_CustomerID = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Info", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Account_Info_Customer_Info_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer_Info",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investment_Info",
                columns: table => new
                {
                    InvestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    FormType = table.Column<string>(nullable: true),
                    Ques1 = table.Column<string>(nullable: true),
                    Ques2 = table.Column<string>(nullable: true),
                    Ques3 = table.Column<string>(nullable: true),
                    Ques4 = table.Column<string>(nullable: true),
                    Ques5 = table.Column<string>(nullable: true),
                    Ques6 = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    Bene_FirstName = table.Column<string>(nullable: true),
                    Bene_LastName = table.Column<string>(nullable: true),
                    Bene_Contact = table.Column<string>(nullable: true),
                    Bene_Relationship = table.Column<string>(nullable: true),
                    Bene_Email = table.Column<string>(nullable: true),
                    BenAddress = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investment_Info", x => x.InvestID);
                    table.ForeignKey(
                        name: "FK_Investment_Info_Customer_Info_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer_Info",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CusTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    TransactionAmount = table.Column<float>(nullable: false),
                    TransactionType = table.Column<string>(nullable: false),
                    Trans_AccountNumber = table.Column<string>(nullable: false),
                    Trans_OtherAccount = table.Column<string>(nullable: false),
                    Trans_CustomerID = table.Column<string>(nullable: false),
                    Trans_EmployeeID = table.Column<string>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: false),
                    Trans_TransactionStatus = table.Column<string>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    AccountNumber = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CusTransaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_CusTransaction_Account_Info_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Account_Info",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CusTransaction_Customer_Info_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer_Info",
                        principalColumn: "CustomerID"
                        /*onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_CusTransaction_Employee_Info_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee_Info",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Info_CustomerID",
                table: "Account_Info",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CusTransaction_AccountNumber",
                table: "CusTransaction",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CusTransaction_CustomerID",
                table: "CusTransaction",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CusTransaction_EmployeeID",
                table: "CusTransaction",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Investment_Info_CustomerID",
                table: "Investment_Info",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CusTransaction");

            migrationBuilder.DropTable(
                name: "Investment_Info");

            migrationBuilder.DropTable(
                name: "Account_Info");

            migrationBuilder.DropTable(
                name: "Employee_Info");

            migrationBuilder.DropTable(
                name: "Customer_Info");
        }
    }
}
