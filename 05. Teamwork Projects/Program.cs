using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());
            RegisterTeams(teams, teamsCount);
            string command = Console.ReadLine();
            while(command!= "end of assignment")
            {
                string[] joinArgs = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                 string memberName = joinArgs[0];
                 string joinTeam = joinArgs[1];
                Team searchTeam = teams.FirstOrDefault(t => t.Name == joinTeam);
                if (searchTeam == null)
                {
                    Console.WriteLine($"Team {joinTeam} does not exist!");
                    command = Console.ReadLine();
                    continue;
                }
                if (IsAlredyMemberOfTeam(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {joinTeam}!");
                    command = Console.ReadLine();
                    continue;
                }
                if (teams.Any(t => t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {joinTeam}!");
                    command = Console.ReadLine();
                    continue;
                }
                searchTeam.AddMember(memberName);
                command = Console.ReadLine();
            }
            List<Team> teamsWithMembers =
            teams.Where(t => t.Members.Count > 0)
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.Name)
            .ToList();
            List<Team> teamsToDisband = 
                teams.Where(t => t.Members.Count == 0)
                .OrderBy(t=>t.Name)
                .ToList();
            PrintValidTeams(teamsWithMembers);
            PrintInvalidTeams(teamsToDisband);
         
        }
        static void RegisterTeams(List<Team>teams,int n)
        {
            for (int curTeam = 1; curTeam <=n; curTeam++)
            {
                string[] teamArgs = Console.ReadLine()
               .Split('-', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];
                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }
                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
        }
        static bool IsAlredyMemberOfTeam(List<Team>teams,string member)
        {
            foreach(Team team in teams)
            {
                if (team.Members.Contains(member))
                {
                    return true;
                }
            }
            return false;
        }
        static void PrintValidTeams(List<Team>validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");
                foreach (string currMember in validTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {currMember}");
                }

            }
        }
        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }
    }
    class Team
    {
        public Team(string teamName,string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;
            this.Members = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public void AddMember(string member)
        {
            this.Members.Add(member);
        }

    }
}
