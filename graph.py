import queue as qu
import time
import sys
import math
import heapq


class Graph():
    def __init__(self, gDict=None):
        self.gDict = {}
        self.time = 0
        self.toppo = []

    def addVertex(self, vertex):
        if vertex not in self.gDict:
            v = Vertex(vertex)
            v.color = 'w'
            self.gDict[vertex] = v

    def addEdge(self, fromV, toV):
        if fromV not in self.gDict.keys():
            self.addVertex(fromV)
            t = Vertex(toV)
            if toV.rstrip() not in self.gDict.keys():
                self.addVertex(toV)
            self.gDict[fromV].addNeighbor(t)
            self.gDict[toV].addNeighbor(Vertex(fromV))

        else:
            if toV.rstrip() not in self.gDict.keys():
                self.addVertex(toV)
                self.gDict[toV].addNeighbor(Vertex(fromV))
            t = Vertex(toV)
            self.gDict[fromV].addNeighbor(t)
            self.gDict[toV].addNeighbor(Vertex(fromV))

    def addDEdge(self, fromV, toV, weight):
         if fromV not in self.gDict.keys():
            self.addVertex(fromV)
            t = Vertex(toV)
            t.weight = weight
            self.gDict[fromV].addNeighbor(t)
         else:
            t = Vertex(toV)
            t.weight = weight
            self.gDict[fromV].addNeighbor(t)
            


    def BFS(self, s):
        sV = self.gDict[s]
        q = qu.Queue()
        #visited = set()
        q.put(sV)
        while q.qsize() > 0:
            neighbor = q.get()
            for edge in self.gDict[str(neighbor)].edges:
                if self.gDict[str(edge)].color is 'w':
                    self.gDict[str(edge)].color = 'g'
                    self.gDict[str(edge)].parent = neighbor
                    q.put(edge)
            neighbor.color = 'b'
       

    def DFSVisit(self, vertex):
        self.time = self.time + 1
        self.gDict[str(vertex)].start = self.time
        self.gDict[str(vertex)].color = 'g'
        for edge in self.gDict[str(vertex)].edges:
            if self.gDict[str(edge)].color == 'w':
                self.gDict[str(edge)].parent = vertex
                self.DFSVisit(edge)
        vertex.color = 'b'
        self.time = self.time + 1
        self.gDict[str(vertex)].finish = self.time
        self.toppo.insert(0,vertex)
        
        
    def DFSTop(self,v):
        self.time = 0
        for vertex in self.gDict.values():
            if vertex.color == 'w':
                self.DFSVisit(vertex)


    def DFS(self,v):
        self.time = 0
        for vertex in sorted(self.gDict.keys()):
            if self.gDict[vertex].color == 'w':
                self.DFSVisit(self.gDict[vertex])
                

    def MSTPrim(self,r):
        for v in self.gDict.keys():
            self.gDict[v].distance = sys.maxsize
        self.gDict[r].distance = 0
        q = qu.PriorityQueue()
        for v in self.gDict.keys():
            q.put((self.gDict[v].distance,self.gDict[v].key))
        while q.qsize()>0:
            cV = q.get()[1]
            for neighbor in self.gDict[str(cV)].edges:
                cost = neighbor.weight
                if neighbor.key in (x[1] for x in q.queue) and float(cost)<float(self.gDict[str(neighbor)].distance):
                    self.gDict[str(neighbor)].parent = self.gDict[cV]
                    self.gDict[str(neighbor)].distance = cost
                    for a in q.queue:
                        if a[1] == neighbor.key:
                            q.queue.remove(a)
                            q.put((float(cost),neighbor.key))
                            
                        
                    
        


        

    
    def printPath(self,source,destination,path=[]):
        if not(isinstance(source,Vertex)):
            source = self.gDict[source]
        if not(isinstance(destination,Vertex)):
            destination = self.gDict[destination]
        path+=[str(destination)]
        if destination.key == source.key:
            print("Path found",end=':')
            #print(source.key)#, end=' ')
            #path.append(source.key)
            for k in reversed(path):
                print(str(k),end=',')
            print()
            print()
        elif destination.parent == None:
            print("no path exists")
            print()
            
        else:
            self.printPath(source,destination.parent.key,path)
            #print(", " + destination.key,end=' ')
            #path.insert(0,str(destination))


   


class Vertex():
    def __init__(self, key,parent=None):
        self.key = key
        self.edges = []
        self.parent = parent
        self.color = 'w'
        self.start = 0
        self.finish = 0
        self.weight = 0
        self.distance = sys.maxsize

    def __str__(self):
        return self.key.rstrip()

    def addNeighbor(self, toV):
        if toV not in self.edges:
            self.edges.append(toV)

def gMake(fileName):
    fp = open(fileName, 'r')
    ar = []
    t1 = []
    t2 = []
    i = 2
    arS = fp.read()
    ar = arS.split('\n')
    while i < len(ar)-1:
        st = ar[i]
        st = st.split(' ')
        t1.append(st[0].rstrip())
        t2.append(st[1].rstrip())
        i += 1
    g = Graph()
    i = 0
    while i < len(t1):
        g.addEdge(t1[i], t2[i])
        i += 1
    return g

def gDMake(fileName):
    fp = open(fileName, 'r')
    ar = []
    t1 = []
    t2 = []
    t3 = []
    
    i = 2
    arS = fp.read()
    ar = arS.split('\n')
    while i < len(ar)-1:
        st = ar[i].rstrip()
        st = st.split(' ')
        stClean = []
        for k in st:
            if k != '':
                stClean.append(k)
        t1.append(stClean[0].rstrip())
        t2.append(stClean[1].rstrip())
        t3.append(stClean[2].rstrip())
        i += 1
    g = Graph()
    i = 0
    while i < len(t1):
        g.addDEdge(t1[i], t2[i],t3[i])
        i += 1
    return g

#timeS = time.clock()
#g = gMake('mediumG.txt')
#gD = gDMake('mediumDG.txt')
g = gDMake('tinyDG.txt')
#print("Time to make graph: " + str(time.clock()-timeS))
#timeS = time.clock()
#g.DFS('1')
#gD.DFSTop('0')
#gL.BFS('72')
#print(str(time.clock()-timeS))
'''for v in sorted(gD.gDict.keys()):
    print(gD.gDict[v].key,end=': ')
    for edge in gD.gDict[v].edges:
        print(edge.key + ', ' + str(edge.weight),end='; ')
    print()'''

g.MSTPrim('7')
for a in g.gDict.values():
    if a.parent != None:
        print(a.parent.key + " -> " + a.key + ": " +str(a.distance))

'''q = qu.PriorityQueue()

q.put((7,'z1'))
q.put((6,'z2'))
q.put((5,'z3'))
q.put((14,'z4'))
q.put((9,'z5'))

for a in q.queue:
    if a[1] == 'z3':
        q.queue.remove(a)
        q.put((2,'zNew'))

print(q.get()[1])'''


   


