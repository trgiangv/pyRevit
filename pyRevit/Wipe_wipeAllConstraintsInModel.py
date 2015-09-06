from Autodesk.Revit.DB import *
import StringIO
outputs = StringIO.StringIO()

def report(message):
	#print(message)
	outputs.write(message)
	outputs.write('\n')

uidoc = __revit__.ActiveUIDocument
doc = __revit__.ActiveUIDocument.Document
selection = [ doc.GetElement( elId ) for elId in __revit__.ActiveUIDocument.Selection.GetElementIds() ]

delConst = True

cl = FilteredElementCollector(doc)
clconst = cl.OfCategory( BuiltInCategory.OST_Constraints ).WhereElementIsNotElementType()

constlst = set()

def listConsts( el, clconst ):
	report('SEARCHING FOR CONSTRAINTS ON OBJECT ID: {0}'.format(el.Id))
	for cnst in clconst:
		refs = [(x.ElementId, x) for x in cnst.References]
		elids = [x[0] for x in refs]
		if el.Id in elids:
			constlst.add( cnst )
			report("CONST TYPE: {0} # OF REFs: {1} CONST ID: {2}".format(cnst.GetType().Name.ljust(28), str(cnst.References.Size).ljust(24), cnst.Id))
			for t in refs:
				ref = t[1]
				elid = t[0]
				if elid == el.Id:
					elid = str(elid) + ' (this)'
				report("     {0} LINKED OBJ CATEGORY: {1} ID: {2}".format( ref.ElementReferenceType.ToString().ljust(35), doc.GetElement( ref.ElementId ).Category.Name.ljust(20), elid))
			report('\n')
	report('\n')

#list all elements in a model
cl = FilteredElementCollector( doc )
cl.WherePasses( LogicalOrFilter( ElementIsElementTypeFilter( False ), ElementIsElementTypeFilter( True ) ) )
list = [i for i in cl]

for el in list:
	listConsts(el, clconst)

report( '\n\n' )
print( outputs.getvalue() )

if delConst:
	if constlst:
		with Transaction(doc, 'Remove all constraints') as t:
			t.Start()
			for cnst in constlst:
				try:
					print("REMOVING CONST TYPE: {0} # OF REFs: {1} CONST ID: {2}".format(cnst.GetType().Name.ljust(28), str(cnst.References.Size).ljust(24), cnst.Id)) 
					doc.Delete(cnst.Id)
					print('CONST REMOVED')
				except:
					print('FAILED')
					continue
			t.Commit()
	else:
		print('NO CONSTRAINTS FOUND.')