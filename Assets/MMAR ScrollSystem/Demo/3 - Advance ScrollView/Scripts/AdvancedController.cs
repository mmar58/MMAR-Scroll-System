using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.ScrollSystem.Demo
{
    public class AdvancedController : Controller
    {
        public float width;
        public float height;
        private void Start()
        {
            dataList= new List<Data>
        {
            new AdvancedData(0,"John", "Doe", 30, "Software Developer"),
            new AdvancedData(1,"Jane", "Smith", 25, "Graphic Designer"),
            new AdvancedData(2,"Michael", "Johnson", 40, "Project Manager"),
            new AdvancedData(3,"Emily", "Davis", 28, "Marketing Specialist"),
            new AdvancedData(4,"David", "Wilson", 35, "Data Analyst"),
            new AdvancedData(5,"Sarah", "Brown", 22, "Sales Representative"),
            new AdvancedData(6,"James", "Taylor", 45, "Financial Advisor"),
            new AdvancedData(7,"Jessica", "Anderson", 33, "Human Resources"),
            new AdvancedData(8,"Robert", "Thomas", 29, "Web Developer"),
            new AdvancedData(9,"Olivia", "Jackson", 27, "UX Designer"),
            new AdvancedData(10,"Daniel", "White", 38, "Accountant"),
            new AdvancedData(11,"Sophia", "Harris", 24, "Digital Marketer"),
            new AdvancedData(12,"William", "Martin", 31, "Business Analyst"),
            new AdvancedData(13,"Mia", "Thompson", 26, "Content Writer"),
            new AdvancedData(14,"Matthew", "Garcia", 37, "IT Support Specialist"),
            new AdvancedData(15,"Ava", "Martinez", 32, "Operations Manager"),
            new AdvancedData(16,"Joshua", "Robinson", 28, "Software Engineer"),
            new AdvancedData(17,"Isabella", "Clark", 23, "Social Media Manager"),
            new AdvancedData(18,"Andrew", "Rodriguez", 34, "Product Manager"),
            new AdvancedData(19,"Amelia", "Lewis", 30, "Public Relations"),
            new AdvancedData(20,"Joseph", "Lee", 36, "Civil Engineer"),
            new AdvancedData(21,"Charlotte", "Walker", 27, "Customer Support"),
            new AdvancedData(22,"Christopher", "Hall", 39, "Network Administrator"),
            new AdvancedData(23,"Evelyn", "Allen", 25, "Event Coordinator"),
            new AdvancedData(24,"Anthony", "Young", 29, "Mechanical Engineer"),
            new AdvancedData(25,"Abigail", "Hernandez", 31, "Legal Assistant"),
            new AdvancedData(26,"Brian", "King", 42, "Architect"),
            new AdvancedData(27,"Harper", "Wright", 33, "Fashion Designer"),
            new AdvancedData(28,"Ryan", "Lopez", 35, "Supply Chain Manager"),
            new AdvancedData(29,"Ella", "Hill", 24, "HR Specialist"),
            new AdvancedData(30,"Kevin", "Scott", 37, "Pharmacist"),
            new AdvancedData(31,"Grace", "Green", 26, "Product Designer"),
            new AdvancedData(32,"Jason", "Adams", 30, "Software Tester"),
            new AdvancedData(33,"Zoe", "Baker", 23, "Graphic Artist"),
            new AdvancedData(34,"George", "Nelson", 45, "Logistics Coordinator"),
            new AdvancedData(35,"Chloe", "Carter", 29, "Medical Assistant"),
            new AdvancedData(36,"Timothy", "Mitchell", 41, "Electrical Engineer"),
            new AdvancedData(37,"Lily", "Perez", 27, "Customer Service"),
            new AdvancedData(38,"Jeffrey", "Roberts", 34, "Construction Manager"),
            new AdvancedData(39,"Aria", "Turner", 25, "Interior Designer"),
            new AdvancedData(40,"Paul", "Phillips", 38, "System Analyst"),
            new AdvancedData(41,"Madison", "Campbell", 28, "Project Coordinator"),
            new AdvancedData(42,"Brandon", "Parker", 33, "IT Consultant"),
            new AdvancedData(43,"Victoria", "Evans", 24, "Brand Manager"),
            new AdvancedData(44,"Adam", "Edwards", 36, "Financial Analyst"),
            new AdvancedData(45,"Scarlett", "Collins", 29, "SEO Specialist"),
            new AdvancedData(46,"Patrick", "Stewart", 32, "Civil Engineer"),
            new AdvancedData(47,"Penelope", "Sanchez", 31, "UI/UX Designer"),
            new AdvancedData(48,"Jonathan", "Morris", 44, "Senior Developer"),
            new AdvancedData(49,"Lillian", "Rogers", 26, "Market Researcher"),
            new AdvancedData(50,"Stephen", "Reed", 37, "Database Administrator"),
            new AdvancedData(51,"Hannah", "Cook", 23, "Sales Manager"),
            new AdvancedData(52,"Mark", "Morgan", 39, "Account Manager"),
            new AdvancedData(53,"Avery", "Bell", 28, "Product Manager"),
            new AdvancedData(54,"Nicholas", "Murphy", 35, "Network Engineer"),
            new AdvancedData(55,"Leah", "Bailey", 24, "Digital Content Creator"),
            new AdvancedData(56,"Frank", "Rivera", 40, "Business Consultant"),
            new AdvancedData(57,"Addison", "Cooper", 25, "Graphic Designer"),
            new AdvancedData(58,"Raymond", "Richardson", 43, "Software Architect"),
            new AdvancedData(59,"Riley", "Cox", 27, "Data Scientist"),
            new AdvancedData(60,"Dennis", "Howard", 31, "Operations Analyst"),
            new AdvancedData(61,"Nora", "Ward", 22, "PR Coordinator"),
            new AdvancedData(62,"Gary", "Torres", 38, "Quality Assurance Manager"),
            new AdvancedData(63,"Lucy", "Peterson", 30, "Event Planner"),
            new AdvancedData(64,"Alan", "Gray", 34, "Technical Support"),
            new AdvancedData(65,"Ellie", "Ramirez", 29, "Web Designer"),
            new AdvancedData(66,"Jack", "James", 41, "Corporate Trainer"),
            new AdvancedData(67,"Violet", "Watson", 26, "Content Strategist"),
            new AdvancedData(68,"Bruce", "Brooks", 39, "Process Engineer"),
            new AdvancedData(69,"Layla", "Kelly", 24, "Social Media Strategist"),
            new AdvancedData(70,"Patrick", "Sanders", 36, "Human Resources Manager"),
            new AdvancedData(71,"Hazel", "Price", 27, "Sales Associate"),
            new AdvancedData(72,"Eugene", "Bennett", 45, "Project Consultant"),
            new AdvancedData(73,"Zoey", "Wood", 28, "Operations Coordinator"),
            new AdvancedData(74,"Wayne", "Barnes", 33, "Financial Consultant"),
            new AdvancedData(75,"Stella", "Ross", 22, "Customer Success Manager"),
            new AdvancedData(76,"Craig", "Henderson", 32, "Software Analyst"),
            new AdvancedData(77,"Paisley", "Coleman", 25, "Marketing Coordinator"),
            new AdvancedData(78,"Ethan", "Jenkins", 37, "Risk Manager"),
            new AdvancedData(79,"Aurora", "Perry", 30, "IT Manager"),
            new AdvancedData(80,"Victor", "Powell", 44, "Senior Consultant"),
            new AdvancedData(81,"Savannah", "Long", 29, "Brand Strategist"),
            new AdvancedData(82,"Harold", "Patterson", 42, "Software Project Manager"),
            new AdvancedData(83,"Brooklyn", "Hughes", 23, "User Experience Researcher"),
            new AdvancedData(84,"Henry", "Flores", 38, "System Architect"),
            new AdvancedData(85,"Camila", "Washington", 26, "Content Manager"),
            new AdvancedData(86,"Gregory", "Butler", 35, "Business Analyst"),
            new AdvancedData(87,"Nova", "Simmons", 27, "Community Manager"),
            new AdvancedData(88,"Walter", "Foster", 43, "Engineering Manager"),
            new AdvancedData(89,"Elena", "Gonzalez", 31, "HR Consultant"),
            new AdvancedData(90,"Aaron", "Bryant", 39, "Data Engineer"),
            new AdvancedData(91,"Aubrey", "Alexander", 24, "Digital Marketing Analyst"),
            new AdvancedData(92,"Jerry", "Russell", 40, "Technical Architect"),
            new AdvancedData(93,"Sofia", "Griffin", 25, "Public Relations Manager")
        };
            RefreshView();
            updatePagination = true;
        }
        public override float GetWidth(int index)
        {
            return width;
        }
        public override float GetHeight(int index)
        {
            return height;
        }
    }
}