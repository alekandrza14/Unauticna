-- defines a Jump function
function Build (patrn)
for i=1,5,1 do
for j=1,2,1 do
for k=1,2,1 do

        vec3.Add(i*20)
        vec3.Add((j+i)*20)
        vec3.Add(k*20)
end
end    
end
return vec3;
end


function Item (patrn)
for i=1,5,1 do
for j=1,2,1 do
for k=1,2,1 do

        ditem.Add("dange_4D_home");
end
end    
end
return ditem;
end