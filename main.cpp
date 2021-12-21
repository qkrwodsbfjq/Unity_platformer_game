#include <iostream>

#include <algorithm>

#include <vector>

#include <queue>

using namespace std;

vector<vector<int>> adj;


void bfs2(int start, vector<int>& distance, vector<int>& parent)

{

	distance = vector<int>(adj.size(), -1);

	parent = vector<int>(adj.size(), -1);

	queue<int> q;

	distance[start] = 0;

	parent[start] = start;

	q.push(start);

	while (!q.empty())

	{

		int here = q.front();

		q.pop();

		for (int i = 0; i < adj[here].size(); ++i)

		{

			int there = adj[here][i];

			if (distance[there] == -1) {

				distance[there] = distance[here] + 1;

				parent[there] = here;

				q.push(there);

			}

		}

	}

}

vector<int> shortestPath(int v, const vector<int>& parent)

{

	vector<int> path(1, v);



	while (parent[v] != v)

	{

		v = parent[v];

		path.push_back(v);

	}

	reverse(path.begin(), path.end());

	return path;

}



int main()

{
	string inputs;
	cin >> inputs;

	int V ;
	cin >> V;

	adj = vector<vector<int>>(V, vector<int>());
	for (int i = 0; i < V; i++) {
		string input;
		cin >> input;
		adj[input[0]].push_back([input[1]);
	}


	vector<int> distance;

	vector<int> parent;

	bfs2(0, distance, parent);



	vector<int> shortestWay;

	string a;
	cin >> a;

	shortestWay = shortestPath(a[0], a[1]);

	for (int i = 0; i < shortestWay.size(); ++i)

		cout << shortestWay[i] << " ";



	return 0;

}