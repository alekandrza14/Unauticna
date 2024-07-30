-- defines a Jump function
function Build (patrn)
for i=0,0+patrn,1 do

        vec3.Add(2)
        vec3.Add(patrn*2+i*2)
        vec3.Add(2)

        vec3.Add(-2)
        vec3.Add(patrn*2+i*2)
        vec3.Add(2)

        vec3.Add(-2)
        vec3.Add(patrn*2+i*2)
        vec3.Add(-2)

        vec3.Add(2)
        vec3.Add(patrn*2+i*2)
        vec3.Add(-2)
end
	

return vec3;
end


function Item (patrn)

for i=0,0+patrn,1 do

ditem.Add("Мясо");
ditem.Add("Мясо");
ditem.Add("Мясо");
ditem.Add("Мясо");


end

return ditem;
end