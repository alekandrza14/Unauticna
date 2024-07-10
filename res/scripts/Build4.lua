-- defines a Jump function
function Build (patrn)
for i=1,2,1 do
for j=0,18,1 do
for k=1,2,1 do

        vec3.Add(i*8)
        vec3.Add((j)*8)
        vec3.Add(k*8)
end
end    
end
return vec3;
end


function Item (patrn)
for i=1,2,1 do
for j=0,18,1 do
for k=1,2,1 do

        ditem.Add("dange_4D_bunker");
end
end    
end
return ditem;
end