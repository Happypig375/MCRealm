#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define MAXLENGTH 100
int strncmp(const char *str1, const char *str2, size_t len);
void proc(const char *Command);
int main(const char *Arguments,...)
{
	system("ver");
	printf("(c) 2016 Happypig375. All rights reserved.\n\n");
	char Command[MAXLENGTH];
	if (Arguments != NULL)
	{

	}
	scanf("%s", Command);
	do
	{
		proc(Command);
	scanf("%s", Command);
} while (Command != "exit")
		;
	//	system("pause");
	return 0;
}
void proc(const char *Command)
{
		if (!strncmp(Command, "echo ", 5))
		{

		}
		else
			system(Command);
}