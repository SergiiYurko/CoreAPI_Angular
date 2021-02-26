import { GroupTechnology } from "../home/Models/GroupTechnology";
import { Technology } from "../home/Models/Technology";

export function groupByTitle(data: Technology[]): GroupTechnology[] {
    var groupByName: GroupTechnology[] = [];
    data.forEach(function (a) {
        var index = groupByName.findIndex(item => item.title == a.groupTitle);
        if (index != -1)
            groupByName[index].technologies.push(a);
        else {
            var technologies: Technology[] = [];
            technologies.push(a);
            groupByName.push({ title: a.groupTitle, technologies: technologies });
        }
    });

    return groupByName;
}

